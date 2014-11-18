using SupperSlonicDomain.DAL;
using SupperSlonicDomain.Models.SourceCodeDownload;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SupperSlonicDomain.Logic
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

        public Task<IList<DownloadInfo>> GetDownloadsInfoAsync()
        {
            return Task<IList<DownloadInfo>>.Factory.StartNew(() =>
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