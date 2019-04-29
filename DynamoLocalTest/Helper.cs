using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tams.core;

namespace DynamoLocalTest
{
    class Helper : DynamoRepository
    {
        public async System.Threading.Tasks.Task CreateExampleTableAsync(string tableName)
        {
            Console.WriteLine("\n*** Creating table ***");
            var request = new CreateTableRequest
            {
                AttributeDefinitions = new List<AttributeDefinition>()
            {
                new AttributeDefinition
                {
                    AttributeName = "id",
                    AttributeType = "S"
                },
                new AttributeDefinition
                {
                    AttributeName = "account_number",
                    AttributeType = "S"
                }
            },
                KeySchema = new List<KeySchemaElement>
            {
                new KeySchemaElement
                {
                    AttributeName = "id",
                    KeyType = "HASH" //Partition key
                },
                new KeySchemaElement
                {
                    AttributeName = "account_number",
                    KeyType = "RANGE" //Sort key
                }
            },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 5,
                    WriteCapacityUnits = 6
                },
                TableName = tableName
            };

            var response = await client.CreateTableAsync(request);

            var tableDescription = response.TableDescription;
            Console.WriteLine("{1}: {0} \t ReadsPerSec: {2} \t WritesPerSec: {3}",
                      tableDescription.TableStatus,
                      tableDescription.TableName,
                      tableDescription.ProvisionedThroughput.ReadCapacityUnits,
                      tableDescription.ProvisionedThroughput.WriteCapacityUnits);

            string status = tableDescription.TableStatus;
            Console.WriteLine(tableName + " - " + status);

            await WaitUntilTableReadyAsync(tableName);
        }

        private async System.Threading.Tasks.Task WaitUntilTableReadyAsync(string tableName)
        {
            string status = null;
            // Let us wait until table is created. Call DescribeTable.
            do
            {
                System.Threading.Thread.Sleep(5000); // Wait 5 seconds.
                try
                {
                    var res = await client.DescribeTableAsync(new DescribeTableRequest
                    {
                        TableName = tableName
                    });

                    Console.WriteLine("Table name: {0}, status: {1}",
                              res.Table.TableName,
                              res.Table.TableStatus);
                    status = res.Table.TableStatus;
                }
                catch (ResourceNotFoundException)
                {
                    // DescribeTable is eventually consistent. So you might
                    // get resource not found. So we handle the potential exception.
                }
            } while (status != "ACTIVE");
        }


    }
}
