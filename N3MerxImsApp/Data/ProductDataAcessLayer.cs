using Dapper;
using Microsoft.Data.SqlClient;
using N3MerxImsApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace N3MerxImsApp.Data
{
    public class ProductDataAcessLayer
    {
        public IConfiguration Configuration;
        private const string MERXIMS_DATABASE = "LocalConnection";
        private const string SELECT_PRODUCTS = "select * from products";
        private const string INSERT_PRODUCTS = "INSERT INTO Products (Name, ContactId, ProductTypeId, ContactProductId, Note, ImageUrl, InStock, CalcStock, CalcStockNote, CalcStockDate, UpdateDate, IsActive) VALUES(@Name, @ContactId, @ProductTypeId, @ContactProductId, @Note, @ImageUrl, @InStock, @CalcStock, @CalcStockNote, @CalcStockDate, @UpdateDate, @IsActive)";
        private const string UPDATE_PRODUCTS = "UPDATE Products SET [Name] = @Name, [ContactId] = @ContactId, [ProductTypeId] = @ProductTypeId, [ContactProductId] = @ContactProductId, Note = @Note, ImageUr = @ImageUrl, InStock = @InStock, CalcStock = @CalcStock, CalcStockNote = @CalcStockNote, CalcStockDate] = @CalcStockDate, UpdateDate = @UpdateDate, IsActive = @IsActive WHERE Id = @id";

        public ProductDataAcessLayer( IConfiguration configuration)
        {
            Configuration = configuration;  
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(MERXIMS_DATABASE)))
            {
                db.Open();
                IEnumerable<Product> result = await db.QueryAsync<Product>(SELECT_PRODUCTS);
                return result.ToList();
            }
        }

        public async Task<int> GetProductCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(MERXIMS_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from products");
                return result;
            }
        }

        public async Task AddProductAsync(Product product)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(MERXIMS_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync(INSERT_PRODUCTS, product);
            }
        }

    }
}