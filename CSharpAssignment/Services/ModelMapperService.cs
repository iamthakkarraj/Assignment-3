using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CSharpAssignment.Services {
    public class ModelMapperService {

        /// <summary>
        /// Maps The SourceType Data Into DestinationType Data
        /// </summary>
        /// <typeparam name="SourceType">Data Type Of Source Data</typeparam>
        /// <typeparam name="DestinationType">Data Type In Which You Want To Map Source Data</typeparam>
        /// <param name="Source">Source Data Of SourceType</param>
        /// <returns>Returns Source Data Into DestinationType Object</returns>
        public static DestinationType Map<SourceType, DestinationType>(SourceType Source) {

            MapperConfiguration MConfig = new MapperConfiguration(config => {
                config.CreateMap<SourceType, DestinationType>();
            });            

            return (DestinationType) 
                    Convert
                    .ChangeType(
                        MConfig
                        .CreateMapper()
                        .Map<SourceType, DestinationType>(Source), 
                        typeof(DestinationType));

        }

    }
}