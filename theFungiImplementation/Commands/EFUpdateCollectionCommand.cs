//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using theFungiApplication.Commands;
//using theFungiApplication.DataTransfer;
//using theFungiDataAccess;
//using theFungiImplementation.Validators;

//namespace theFungiImplementation.Commands
//{
//    public class EFUpdateCollectionCommand : IUpdateCollectionCommand
//    {
//        private readonly theFungiDbContext _db;
//        private readonly CreateCollectionValidator _validator;

//        public EFUpdateCollectionCommand(theFungiDbContext db, CreateCollectionValidator validator)
//        {
//            _validator = validator;
//            _db = db;
//        }
//        public int Id => 6;

//        public string Name => "Update Collection Command";

//        public CollectionCreateDto Execute(int search)
//        {
            
//        }
//    }
//}
