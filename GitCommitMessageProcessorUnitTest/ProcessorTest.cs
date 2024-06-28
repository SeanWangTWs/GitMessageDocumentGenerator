using GitMessageDocumentGenerator;
using GitMessageDocumentGenerator.Model;

namespace GitCommitMessageProcessorUnitTest
{
    public class ProcessorTest
    {
        [Fact]
        public void ProcessorTestCase1()
        {
            string gitMessages = @"commit bbf4256d9446aab4736fc32d41f4c12279aa65f7
Merge: 6ba37fc c08dcc0
Author: Person1 <Person1@test.com>
Date:   Wed Jun 26 15:39:38 2024 +0800

    Merge branch 'release/20240626'

commit c08dcc00cae6ce7739001c711291dd88cc8d9c2d
Author: Person1 <Person1@test.com>
Date:   Wed Jun 26 15:24:22 2024 +0800

    fix: C* R********* ************ Filter bug fixed
    
    修正當搜尋條件有************ 時的錯誤
    
    1.修正搜尋條件有************時取的欄位應該是********而不是********
    2.使用的******被********(*****) Cover
    
    issue:A111111111111001

commit c4d1216d9f319414ca7993cb3819539a11d54293
Merge: fc6d692 6ba37fc
Author: Person2 <Person2@test.com>
Date:   Mon Jun 24 15:36:45 2024 +0800

    Merge tag '20240624_Release' into develop
    
    1.0

commit 6ba37fc6d42ec9ff9dee35e84caaf9205c31c7e1
Merge: 49d73c5 fc6d692
Author: Person2 <Person2@test.com>
Date:   Mon Jun 24 15:36:44 2024 +0800

    Merge branch 'release/20240624_Release'

commit fc6d69267c31176154b578e1187ec03e4f845fe5
Author: Person2 <Person2@test.com>
Date:   Mon Jun 24 15:09:00 2024 +0800

    fix: ********判斷*****時會意外過濾已存在的********
    
    ********預設會補上******參數******
    導致********查詢條件的******頁面讀取異常
    
    1.增加判斷*************物件是否已存在，如果已存在則******************
    
    issue: B111111111111002

commit 64c0ede30bbab1e9eb20a3e78a361248a6a0deb5
Merge: c1cf967 49d73c5
Author: Person2 <Person2@test.com>
Date:   Fri Jun 7 12:27:47 2024 +0800

    Merge tag 'RELEASE' into develop
    
    First Git Flow

commit 49d73c51423a71957101599403d49942ad860098
Merge: 1e5677c c1cf967
Author: Person2 <Person2@test.com>
Date:   Fri Jun 7 12:27:46 2024 +0800

    Merge branch 'release/RELEASE'

commit c1cf967935975eb5763966d8f82eaf233d8c2c0e
Author: Person2 <Person2@test.com>
Date:   Fri Jun 7 12:20:11 2024 +0800

    fix: 同步******中的********
    
    ******中的********有*******，導致發佈時**********，*********檔案
    
    1.在專案檔中******************檔案
    
    issue: C111111111111004

commit 5bd152701a8d815d9f8b58bb7ce5285bac90b19c
Author: Person2 <Person2@test.com>
Date:   Fri Jun 7 12:16:54 2024 +0800

    feat: 登入********後可以在************
    
    新增登入***********後，功能選單上可以**************功能
    
    1.***********中加入*************
    2.***********中加入***********的***********
    3.***********的來源一律***********
    
    issue: C111111111111036

";
            var gcmp = new GitCommitMessagesProcessor();
            List<GitMessageModel> Messages = gcmp.GitMessageSplitter(gitMessages);
            Assert.True(Messages.Count == 9);
        }
    }
}