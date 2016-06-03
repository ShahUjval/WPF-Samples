using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace DependencyMgmt
{
    // Object --> Usecase
    //SRP


    interface ILogService
    {

    }

    [Export(typeof(ILogService))]
    class CloudLogService : ILogService
    {



    }


    abstract class Storage
    {
        public abstract void write();
    }


    class RDBMStoarge : Storage
    {

        public override void write()
        {
            throw new NotImplementedException();
        }
    }
    [Export(typeof(Storage))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]  //singleton 
    class XMLStorage : Storage
    {
        ILogService _serviceRef;

        [ImportingConstructor]
        public XMLStorage(ILogService logService)
        {
            _serviceRef = logService;
        }

        public override void write()
        {
            throw new NotImplementedException();
        }
    }
    

    // High Level Module
    class PersistanceLayer
    {
        //Abstraction of (Generlized Form of) Low Level Module
        Storage _store = null;
        
        [Import]
        internal Storage Store
        {
            get { return _store; }
            set { _store = value; }
        }

        public PersistanceLayer()
        {

        }

        public PersistanceLayer(Storage _store)
        {
            //// control freak
            //_store = new XMLStorage();

            this._store = _store;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Composotion by hand
            //Storage _storageRef = new XMLStorage();
            ////static composition 

            AssemblyCatalog _assemblyCatalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer _diContainer = new CompositionContainer(_assemblyCatalog);

            //Storage _storageRef = _diContainer.GetExportedValue<Storage>();

            //PersistanceLayer _dataAccessLayer = new PersistanceLayer(_storageRef);
            //_dataAccessLayer = new PersistanceLayer(new RDBMStoarge());

            PersistanceLayer _dataAccessLayer = new PersistanceLayer();
            _diContainer.SatisfyImportsOnce(_dataAccessLayer);  // dynemic composition of objects...!!


            #endregion

        }
    }
}
