﻿using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class ProductRepository : BaseRepository<CouponSystemDBContext, ProductInformation>, IProductRepository
    {
        public ProductRepository(CouponSystemDBContext dbContext):base(dbContext)
        {

        }

        public  List<ProductInformation> GetAll()
        {
            return Master.ProductInformations.ToList();
        }

        public Tuple<List<ProductInformation>, long> GetList(int pageIndex, int pageSize)
        {
            try
            {
                List<ProductInformation> producntInfolist = new List<ProductInformation>();
                long count = 0;
                var query = Master.ProductInformations;
                producntInfolist = query.OrderByDescending(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                producntInfolist = query.ToList();
                count = query.LongCount();

                return Tuple.Create(producntInfolist, count);
            }
            catch (Exception ex)
            {
            }
            return Tuple.Create<List<ProductInformation>, long>(new List<ProductInformation>(), 0);
        }

        public void Save(ProductInformation product)
        {
            Master.ProductInformations.Add(product);
        }

        public void UpdateProduct(ProductInformation product)
        {
            Master.ProductInformations.Update(product);
        }
        public int AddProduct(ProductInformation productInfo)
        {
            int id = 0;
            try
            {
                var entity = Master.ProductInformations.Add(productInfo);
                Master.SaveChanges();
                id = entity.Entity.Id;
            }
            catch (Exception ex)
            {
            }
            return id;
        }

        public List<ProductInformation> GetProductsByClassType (ClassTypeEnum type)
        {
           return  Master.ProductInformations.Where(item => item.Type == type).ToList();
        }

        public ProductInformation GetProductById(int ProductId)
        {
            return Master.ProductInformations.Find(ProductId);
        }

        public List<ProductInformation> GetProductsByBatchId(int batchId)
        {
            return Master.ProductInformations.Where(item => item.BatchId == batchId).ToList();
        }

        public void RemoveProductById(int productId)
        {
            ProductInformation product =  GetProductById(productId);
            Master.ProductInformations.Remove(product);
        }


  
    }
}
