using System;

namespace Interview
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
        #region remark
        // Added public id to hide PK at logs/api and so on.
        #endregion
        IComparable PublicId { get; set; }
    }

}