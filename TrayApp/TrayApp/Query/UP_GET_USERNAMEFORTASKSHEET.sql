USE [AAMS_TEST]
GO
/****** Object:  StoredProcedure [dbo].[UP_GET_TA_GETUSERNAMEFORSCANMODULE]    Script Date: 10/05/2013 11:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
 /*        
'COPYRIGHT NOTICE: Ã 2004 BY BIRD INFORMATION SYSTEMS ALL RIGHTS RESERVED.        
'********************************************************************************************        
' THIS FILE CONTAINS TRADE SECRETS OF BIRD INFORMATION SYSTEMS NO PART        
' MAY BE REPRODUCED OR TRANSMITTED IN ANY FORM BY ANY MEANS OR FOR ANY PURPOSE        
' WITHOUT THE EXPRESS WRITTEN PERMISSION OF BIRD INFORMATION SYSTEMS        
'********************************************************************************************        
NAME: [UP_GET_TA_GETUSERNAMEFORSCANMODULE]        
PURPOSE: THIS PROCEDURE WILL GIVE THE THOSE USE NAME WHO VALID FOR SCAN MODULE.        
SL. NO. DATE  DEVELOPER’S NAME ACTIVITY        
1. 22/1/2007  Ashish Kumar
*/        
  
ALTER PROCEDURE [dbo].[UP_GET_USERNAMEFORTASKSHEET]  
As  
BEGIN    
	SELECT FIELD_VALUE FROM T_G_CONFIG WITH(NOLOCK) WHERE FIELD_NAME = 'TASK_SHEET_SOFTWARE_TEAM'  
	
--	update T_G_CONFIG set FIELD_VALUE='RAJVIR,TAPAN,GOPI,ASHISH,ABHISHEK,NEERAJ,DEEPAK,SHELLY' WHERE FIELD_NAME = 'TASK_SHEET_SOFTWARE_TEAM'  
	
END    






