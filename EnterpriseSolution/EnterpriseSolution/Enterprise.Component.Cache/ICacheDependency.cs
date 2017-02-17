using System.Web.Caching;

namespace Enterprise.Component.Cache
{
    /// <summary>
    /// ����ӿ��Ǵ�������������ģʽ�����ص�
    /// ������Ա����ִ������ӿڽ���ͬ���͵Ĵ���������ӵ�pet shop
    /// 
    /// ����ʵ�ּ򵥹���ģʽ�еĳ���ӿڣ������߿���ʵ�ָýӿڳ�Ա����չ������������Ӧ�á�
    /// </summary>
    public interface ICacheDependency
    {

        /// <summary>
        ///�˷����������������ʵ���ִ��
        /// 
        ///�÷������ڻ�ȡ�����ۺϻ���������AggregateCacheDependency��ʵ��
        /// </summary>
        /// <returns>�������漯��������Ĵ������棬�ۺϻ���������AggregateCacheDependency</returns>
        AggregateCacheDependency GetDependency();
    }
}
