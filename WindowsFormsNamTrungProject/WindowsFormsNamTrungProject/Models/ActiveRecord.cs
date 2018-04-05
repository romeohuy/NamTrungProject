


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace ModelDB.Data
{
    
    
    /// <summary>
    /// A class which represents the SanPham table in the NamTrungBS Database.
    /// </summary>
    public partial class SanPham: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SanPham> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SanPham>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SanPham> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(SanPham item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SanPham item=new SanPham();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SanPham> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public SanPham(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SanPham.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SanPham>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SanPham(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public SanPham(Expression<Func<SanPham, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SanPham> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<SanPham> _repo;
            
            if(db.TestMode){
                SanPham.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SanPham>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SanPham> GetRepo(){
            return GetRepo("","");
        }
        
        public static SanPham SingleOrDefault(Expression<Func<SanPham, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SanPham single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SanPham SingleOrDefault(Expression<Func<SanPham, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SanPham single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SanPham, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SanPham, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SanPham> Find(Expression<Func<SanPham, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SanPham> Find(Expression<Func<SanPham, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SanPham> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SanPham> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SanPham> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SanPham> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SanPham> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SanPham> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MaSP";
        }

        public object KeyValue()
        {
            return this.MaSP;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TenSP.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SanPham)){
                SanPham compare=(SanPham)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MaSP;
        }
        
        public string DescriptorValue()
        {
                            return this.TenSP.ToString();
                    }

        public string DescriptorColumn() {
            return "TenSP";
        }
        public static string GetKeyColumn()
        {
            return "MaSP";
        }        
        public static string GetDescriptorColumn()
        {
            return "TenSP";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MaSP;
        public int MaSP
        {
            get { return _MaSP; }
            set
            {
                if(_MaSP!=value){
                    _MaSP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaSP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenSP;
        public string TenSP
        {
            get { return _TenSP; }
            set
            {
                if(_TenSP!=value){
                    _TenSP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenSP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DVT;
        public string DVT
        {
            get { return _DVT; }
            set
            {
                if(_DVT!=value){
                    _DVT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DVT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _SLDau;
        public double? SLDau
        {
            get { return _SLDau; }
            set
            {
                if(_SLDau!=value){
                    _SLDau=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SLDau");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _SLTon;
        public double? SLTon
        {
            get { return _SLTon; }
            set
            {
                if(_SLTon!=value){
                    _SLTon=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SLTon");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGiaGoc;
        public double? DonGiaGoc
        {
            get { return _DonGiaGoc; }
            set
            {
                if(_DonGiaGoc!=value){
                    _DonGiaGoc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGiaGoc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGia1;
        public double? DonGia1
        {
            get { return _DonGia1; }
            set
            {
                if(_DonGia1!=value){
                    _DonGia1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGia1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGia2;
        public double? DonGia2
        {
            get { return _DonGia2; }
            set
            {
                if(_DonGia2!=value){
                    _DonGia2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGia2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGia3;
        public double? DonGia3
        {
            get { return _DonGia3; }
            set
            {
                if(_DonGia3!=value){
                    _DonGia3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGia3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<SanPham, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the CauHinh table in the NamTrungBS Database.
    /// </summary>
    public partial class CauHinh: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CauHinh> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CauHinh>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CauHinh> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(CauHinh item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CauHinh item=new CauHinh();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CauHinh> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public CauHinh(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CauHinh.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CauHinh>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CauHinh(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public CauHinh(Expression<Func<CauHinh, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CauHinh> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<CauHinh> _repo;
            
            if(db.TestMode){
                CauHinh.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CauHinh>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CauHinh> GetRepo(){
            return GetRepo("","");
        }
        
        public static CauHinh SingleOrDefault(Expression<Func<CauHinh, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CauHinh single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CauHinh SingleOrDefault(Expression<Func<CauHinh, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CauHinh single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CauHinh, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CauHinh, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CauHinh> Find(Expression<Func<CauHinh, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CauHinh> Find(Expression<Func<CauHinh, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CauHinh> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CauHinh> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CauHinh> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CauHinh> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CauHinh> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CauHinh> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Ten.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CauHinh)){
                CauHinh compare=(CauHinh)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Ten.ToString();
                    }

        public string DescriptorColumn() {
            return "Ten";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Ten";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set
            {
                if(_Ten!=value){
                    _Ten=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Ten");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GiaTri;
        public string GiaTri
        {
            get { return _GiaTri; }
            set
            {
                if(_GiaTri!=value){
                    _GiaTri=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GiaTri");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<CauHinh, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the KhachHang table in the NamTrungBS Database.
    /// </summary>
    public partial class KhachHang: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<KhachHang> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<KhachHang>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<KhachHang> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(KhachHang item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                KhachHang item=new KhachHang();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<KhachHang> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public KhachHang(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                KhachHang.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<KhachHang>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public KhachHang(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public KhachHang(Expression<Func<KhachHang, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<KhachHang> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<KhachHang> _repo;
            
            if(db.TestMode){
                KhachHang.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<KhachHang>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<KhachHang> GetRepo(){
            return GetRepo("","");
        }
        
        public static KhachHang SingleOrDefault(Expression<Func<KhachHang, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            KhachHang single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static KhachHang SingleOrDefault(Expression<Func<KhachHang, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            KhachHang single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<KhachHang, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<KhachHang, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<KhachHang> Find(Expression<Func<KhachHang, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<KhachHang> Find(Expression<Func<KhachHang, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<KhachHang> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<KhachHang> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<KhachHang> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<KhachHang> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<KhachHang> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<KhachHang> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MaKH";
        }

        public object KeyValue()
        {
            return this.MaKH;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TenKH.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(KhachHang)){
                KhachHang compare=(KhachHang)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MaKH;
        }
        
        public string DescriptorValue()
        {
                            return this.TenKH.ToString();
                    }

        public string DescriptorColumn() {
            return "TenKH";
        }
        public static string GetKeyColumn()
        {
            return "MaKH";
        }        
        public static string GetDescriptorColumn()
        {
            return "TenKH";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MaKH;
        public int MaKH
        {
            get { return _MaKH; }
            set
            {
                if(_MaKH!=value){
                    _MaKH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaKH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenKH;
        public string TenKH
        {
            get { return _TenKH; }
            set
            {
                if(_TenKH!=value){
                    _TenKH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenKH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DienThoai;
        public string DienThoai
        {
            get { return _DienThoai; }
            set
            {
                if(_DienThoai!=value){
                    _DienThoai=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DienThoai");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set
            {
                if(_DiaChi!=value){
                    _DiaChi=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DiaChi");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CapKH;
        public int? CapKH
        {
            get { return _CapKH; }
            set
            {
                if(_CapKH!=value){
                    _CapKH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CapKH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _TienNo;
        public double? TienNo
        {
            get { return _TienNo; }
            set
            {
                if(_TienNo!=value){
                    _TienNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TienNo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DaTra;
        public double? DaTra
        {
            get { return _DaTra; }
            set
            {
                if(_DaTra!=value){
                    _DaTra=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DaTra");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _ConNo;
        public double? ConNo
        {
            get { return _ConNo; }
            set
            {
                if(_ConNo!=value){
                    _ConNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ConNo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _TongTien;
        public double? TongTien
        {
            get { return _TongTien; }
            set
            {
                if(_TongTien!=value){
                    _TongTien=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TongTien");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set
            {
                if(_GhiChu!=value){
                    _GhiChu=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GhiChu");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<KhachHang, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the ChiTietHoaDon table in the NamTrungBS Database.
    /// </summary>
    public partial class ChiTietHoaDon: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<ChiTietHoaDon> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<ChiTietHoaDon>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<ChiTietHoaDon> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(ChiTietHoaDon item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                ChiTietHoaDon item=new ChiTietHoaDon();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<ChiTietHoaDon> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public ChiTietHoaDon(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                ChiTietHoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ChiTietHoaDon>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public ChiTietHoaDon(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public ChiTietHoaDon(Expression<Func<ChiTietHoaDon, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<ChiTietHoaDon> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<ChiTietHoaDon> _repo;
            
            if(db.TestMode){
                ChiTietHoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ChiTietHoaDon>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<ChiTietHoaDon> GetRepo(){
            return GetRepo("","");
        }
        
        public static ChiTietHoaDon SingleOrDefault(Expression<Func<ChiTietHoaDon, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            ChiTietHoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static ChiTietHoaDon SingleOrDefault(Expression<Func<ChiTietHoaDon, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            ChiTietHoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<ChiTietHoaDon, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<ChiTietHoaDon, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<ChiTietHoaDon> Find(Expression<Func<ChiTietHoaDon, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<ChiTietHoaDon> Find(Expression<Func<ChiTietHoaDon, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<ChiTietHoaDon> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<ChiTietHoaDon> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<ChiTietHoaDon> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<ChiTietHoaDon> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<ChiTietHoaDon> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<ChiTietHoaDon> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MaChiTiet";
        }

        public object KeyValue()
        {
            return this.MaChiTiet;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TenSP.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(ChiTietHoaDon)){
                ChiTietHoaDon compare=(ChiTietHoaDon)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MaChiTiet;
        }
        
        public string DescriptorValue()
        {
                            return this.TenSP.ToString();
                    }

        public string DescriptorColumn() {
            return "TenSP";
        }
        public static string GetKeyColumn()
        {
            return "MaChiTiet";
        }        
        public static string GetDescriptorColumn()
        {
            return "TenSP";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MaChiTiet;
        public int MaChiTiet
        {
            get { return _MaChiTiet; }
            set
            {
                if(_MaChiTiet!=value){
                    _MaChiTiet=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaChiTiet");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _MaHD;
        public int MaHD
        {
            get { return _MaHD; }
            set
            {
                if(_MaHD!=value){
                    _MaHD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaHD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _MaSP;
        public int MaSP
        {
            get { return _MaSP; }
            set
            {
                if(_MaSP!=value){
                    _MaSP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaSP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _STT;
        public int? STT
        {
            get { return _STT; }
            set
            {
                if(_STT!=value){
                    _STT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenSP;
        public string TenSP
        {
            get { return _TenSP; }
            set
            {
                if(_TenSP!=value){
                    _TenSP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenSP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DVT;
        public string DVT
        {
            get { return _DVT; }
            set
            {
                if(_DVT!=value){
                    _DVT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DVT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _SoLuong;
        public double? SoLuong
        {
            get { return _SoLuong; }
            set
            {
                if(_SoLuong!=value){
                    _SoLuong=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SoLuong");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGia;
        public double? DonGia
        {
            get { return _DonGia; }
            set
            {
                if(_DonGia!=value){
                    _DonGia=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGia");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _ThanhTien;
        public double? ThanhTien
        {
            get { return _ThanhTien; }
            set
            {
                if(_ThanhTien!=value){
                    _ThanhTien=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ThanhTien");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _TonDau;
        public double? TonDau
        {
            get { return _TonDau; }
            set
            {
                if(_TonDau!=value){
                    _TonDau=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TonDau");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _LoiNhuan;
        public double? LoiNhuan
        {
            get { return _LoiNhuan; }
            set
            {
                if(_LoiNhuan!=value){
                    _LoiNhuan=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LoiNhuan");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _LoiNhuanTong;
        public double? LoiNhuanTong
        {
            get { return _LoiNhuanTong; }
            set
            {
                if(_LoiNhuanTong!=value){
                    _LoiNhuanTong=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LoiNhuanTong");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _DonGiaGoc;
        public double? DonGiaGoc
        {
            get { return _DonGiaGoc; }
            set
            {
                if(_DonGiaGoc!=value){
                    _DonGiaGoc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DonGiaGoc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<ChiTietHoaDon, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the LuuHoaDon table in the NamTrungBS Database.
    /// </summary>
    public partial class LuuHoaDon: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<LuuHoaDon> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<LuuHoaDon>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<LuuHoaDon> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(LuuHoaDon item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                LuuHoaDon item=new LuuHoaDon();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<LuuHoaDon> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public LuuHoaDon(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                LuuHoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<LuuHoaDon>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public LuuHoaDon(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public LuuHoaDon(Expression<Func<LuuHoaDon, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<LuuHoaDon> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<LuuHoaDon> _repo;
            
            if(db.TestMode){
                LuuHoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<LuuHoaDon>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<LuuHoaDon> GetRepo(){
            return GetRepo("","");
        }
        
        public static LuuHoaDon SingleOrDefault(Expression<Func<LuuHoaDon, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            LuuHoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static LuuHoaDon SingleOrDefault(Expression<Func<LuuHoaDon, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            LuuHoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<LuuHoaDon, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<LuuHoaDon, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<LuuHoaDon> Find(Expression<Func<LuuHoaDon, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<LuuHoaDon> Find(Expression<Func<LuuHoaDon, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<LuuHoaDon> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<LuuHoaDon> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<LuuHoaDon> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<LuuHoaDon> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<LuuHoaDon> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<LuuHoaDon> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MaHD";
        }

        public object KeyValue()
        {
            return this.MaHD;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TenHoaDon.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(LuuHoaDon)){
                LuuHoaDon compare=(LuuHoaDon)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MaHD;
        }
        
        public string DescriptorValue()
        {
                            return this.TenHoaDon.ToString();
                    }

        public string DescriptorColumn() {
            return "TenHoaDon";
        }
        public static string GetKeyColumn()
        {
            return "MaHD";
        }        
        public static string GetDescriptorColumn()
        {
            return "TenHoaDon";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MaHD;
        public int MaHD
        {
            get { return _MaHD; }
            set
            {
                if(_MaHD!=value){
                    _MaHD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaHD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenHoaDon;
        public string TenHoaDon
        {
            get { return _TenHoaDon; }
            set
            {
                if(_TenHoaDon!=value){
                    _TenHoaDon=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenHoaDon");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MoTa;
        public string MoTa
        {
            get { return _MoTa; }
            set
            {
                if(_MoTa!=value){
                    _MoTa=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MoTa");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CapKH;
        public int? CapKH
        {
            get { return _CapKH; }
            set
            {
                if(_CapKH!=value){
                    _CapKH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CapKH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<LuuHoaDon, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the HoaDon table in the NamTrungBS Database.
    /// </summary>
    public partial class HoaDon: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<HoaDon> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<HoaDon>(new ModelDB.Data.NamTrungBSDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<HoaDon> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(HoaDon item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                HoaDon item=new HoaDon();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<HoaDon> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        ModelDB.Data.NamTrungBSDB _db;
        public HoaDon(string connectionString, string providerName) {

            _db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                HoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<HoaDon>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public HoaDon(){
             _db=new ModelDB.Data.NamTrungBSDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public HoaDon(Expression<Func<HoaDon, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<HoaDon> GetRepo(string connectionString, string providerName){
            ModelDB.Data.NamTrungBSDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new ModelDB.Data.NamTrungBSDB();
            }else{
                db=new ModelDB.Data.NamTrungBSDB(connectionString, providerName);
            }
            IRepository<HoaDon> _repo;
            
            if(db.TestMode){
                HoaDon.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<HoaDon>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<HoaDon> GetRepo(){
            return GetRepo("","");
        }
        
        public static HoaDon SingleOrDefault(Expression<Func<HoaDon, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            HoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static HoaDon SingleOrDefault(Expression<Func<HoaDon, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            HoaDon single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<HoaDon, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<HoaDon, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<HoaDon> Find(Expression<Func<HoaDon, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<HoaDon> Find(Expression<Func<HoaDon, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<HoaDon> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<HoaDon> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<HoaDon> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<HoaDon> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<HoaDon> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<HoaDon> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MaHD";
        }

        public object KeyValue()
        {
            return this.MaHD;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TenHoadon.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(HoaDon)){
                HoaDon compare=(HoaDon)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MaHD;
        }
        
        public string DescriptorValue()
        {
                            return this.TenHoadon.ToString();
                    }

        public string DescriptorColumn() {
            return "TenHoadon";
        }
        public static string GetKeyColumn()
        {
            return "MaHD";
        }        
        public static string GetDescriptorColumn()
        {
            return "TenHoadon";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MaHD;
        public int MaHD
        {
            get { return _MaHD; }
            set
            {
                if(_MaHD!=value){
                    _MaHD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaHD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _MaKH;
        public int MaKH
        {
            get { return _MaKH; }
            set
            {
                if(_MaKH!=value){
                    _MaKH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MaKH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenHoadon;
        public string TenHoadon
        {
            get { return _TenHoadon; }
            set
            {
                if(_TenHoadon!=value){
                    _TenHoadon=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenHoadon");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TenNguoiMua;
        public string TenNguoiMua
        {
            get { return _TenNguoiMua; }
            set
            {
                if(_TenNguoiMua!=value){
                    _TenNguoiMua=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TenNguoiMua");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _NgayMua;
        public DateTime? NgayMua
        {
            get { return _NgayMua; }
            set
            {
                if(_NgayMua!=value){
                    _NgayMua=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NgayMua");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _TongTien;
        public double? TongTien
        {
            get { return _TongTien; }
            set
            {
                if(_TongTien!=value){
                    _TongTien=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TongTien");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _TienNo;
        public double? TienNo
        {
            get { return _TienNo; }
            set
            {
                if(_TienNo!=value){
                    _TienNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TienNo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<HoaDon, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
