using Foundation;
using System;
using UIKit;

namespace SimpleSOAPClient
{
    public partial class BusinessObjectViewController : UIViewController
    {

		public BusinessObject m_businessObject;

		public string TypeId
		{
			get;
			set;
		}

		public string RecId
		{
			get;
			set;
		}

        public BusinessObjectViewController (IntPtr handle) : base (handle)
        {
        }

		public BusinessObjectViewController(string typeId, string recId)
		{
			TypeId = typeId;
			RecId = recId;
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CherwellServiceAPI api = new CherwellServiceAPI();
			m_businessObject = await api.getIndividualBusinessObject(TypeId, RecId);

			//theWebView.LoadHtml(m_businessObject.DisplayHtml);


		}
    }
}