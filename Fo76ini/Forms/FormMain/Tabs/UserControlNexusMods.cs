using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlNexusMods : UserControl
    {
        public UserControlNexusMods()
        {
            InitializeComponent();

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "labelNMUserID",
                "labelNMHourlyRateLimit",
                "labelNMAPIKeyStatus",
                "labelNMUserName",
                "labelNMDailyRateLimitReset",
                "labelNMMembership",
                "labelNMDailyRateLimit"
            });

            // SingleSignOn.SSOFinished += SingleSignOn_SSOFinished;
        }
    }
}
