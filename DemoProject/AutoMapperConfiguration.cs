using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace DemoProject
{
    public class AutoMapperConfiguration {
        private static bool mappingConfigured = false;

        public static void ConfigureMapping() {
            // Mapper.CreateMap<來源, 目標>()

            if (mappingConfigured) {
                return;
            }

            Mapper.CreateMap<DAL.Order, DemoProject.Models.OrderModel>();
            Mapper.CreateMap<DemoProject.Models.OrderModel, DAL.Order>();
        }

        public static void CleanupMapping() {
            Mapper.Reset();
            mappingConfigured = false;
        }
    }
}