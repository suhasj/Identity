using System;

namespace Microsoft.AspNet.Identity
{
    public class UserNotification : UserNotification<string>
    {
    }

    public class UserNotification<TKey> where TKey : IEquatable<TKey>
    {
        public virtual int Id { get; set; }

        public virtual TKey UserId { get; set; }

        public virtual DateTimeOffset ActivityTime { get; set; }

        public virtual string Activity { get; set; }
    }
}