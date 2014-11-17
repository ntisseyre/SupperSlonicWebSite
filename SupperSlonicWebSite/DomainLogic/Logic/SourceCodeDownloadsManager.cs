using SupperSlonicWebSite.DomainLogic.DAL;
using SupperSlonicWebSite.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SupperSlonicWebSite.DomainLogic.Logic
{
    public class SourceCodeDownloadsManager
    {
        public IBaseDAL BaseDal { get; set; }
        public ISourceCodeDownloadsDAL Dal { get; set; }

        public SourceCodeDownloadsManager()
        {
            this.BaseDal = new BaseDAL();
            this.Dal = new SourceCodeDownloadsDAL();
        }

        public Task<IList<DownloadInfoModel>> GetDownloadsInfoAsync()
        {
            return Task<IList<DownloadInfoModel>>.Factory.StartNew(() =>
            {
                return this.BaseDal.Execute(IsolationLevel.ReadCommitted,
                (tran) =>
                {
                    return this.Dal.GetDownloadsInfo(tran);
                });
            });
        }

        public void CreateDownloadAsync(string codeName)
        {
            Task.Factory.StartNew(() =>
            {
                this.BaseDal.Execute(IsolationLevel.ReadUncommitted,
                (tran) =>
                {
                    this.Dal.CreateDownload(tran, codeName);
                });
            });
        }
    }
}