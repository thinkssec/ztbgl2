
namespace Enterprise.Service.Common.Webmail
{
    public enum MailState
    {
        /// <summary>
        /// 未发送
        /// </summary>
        NotSend = -1,
        /// <summary>
        /// 正在发送
        /// </summary>
        Sending = 0,
        /// <summary>
        /// 已发送
        /// </summary>
        Send = 1,
        /// <summary>
        /// 发送失败
        /// </summary>
        Failed = 2
    }
}
