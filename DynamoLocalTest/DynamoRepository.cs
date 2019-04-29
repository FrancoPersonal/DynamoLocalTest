namespace Tams.core
{
    using System;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.Runtime;

    public abstract class DynamoRepository : IDisposable
    {
        protected readonly AmazonDynamoDBClient client;
        protected readonly IDynamoDBContext context;

#if DEBUG

        BasicAWSCredentials credentials = new BasicAWSCredentials("IntegrationTestingKey", "IntegrationTestingKey");

        private readonly AmazonDynamoDBConfig config = new AmazonDynamoDBConfig()
        {
            ServiceURL = "http://localhost:8000"
        };
#endif

        public DynamoRepository()
        {
#if DEBUG
            this.client = new AmazonDynamoDBClient(this.credentials,this.config);
#else
              client = new AmazonDynamoDBClient();
#endif
            this.context = new DynamoDBContext(this.client, new DynamoDBContextConfig { ConsistentRead = true, IgnoreNullValues = true });
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.client.Dispose();
                    this.context.Dispose();
                }

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DynamoRepository()
        {
            this.Dispose(false);
        }

    }
}
