using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;

namespace Catelog.Infrastructure.Tests.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed<T>(this ModelBuilder builder, string file) where T : class
        {
            using(var reader=new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);
                builder.Entity<T>().HasData(data);
            }

            return builder;
        }
    }
}
