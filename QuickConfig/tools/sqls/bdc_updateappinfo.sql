update framework.t_common_appinfo set aliasname='{in_xzqmc}'||'����ƽ̨' ,
ssourl='~/oSystem/Frame/Default/sysFrame.html' where appcode='WEBAPP_0001';


update framework.t_common_appinfo set aliasname='{in_xzqmc}'||'�������ǼǷ�֤ϵͳ' ,
ssourl='http://'||'{in_ip}'||':8025/Account/SSOLogin.html' ,websiteurl='http://'||'{in_ip}:8025' where appcode='WEBAPP_0002';


update framework.t_common_appinfo set aliasname='{in_xzqmc}'||'������ϵͳ' ,
ssourl='http://'||'{in_ip}'||':8028/Account/SSOLogin.html' where appcode='WEBAPP_0003';


update framework.t_common_appinfo set aliasname='{in_xzqmc}'||'����ϵͳ' ,
ssourl='http://'||'{in_ip}'||':8030/Account/SSOLogin.html' where appcode='WEBAPP_0004';

exit;
