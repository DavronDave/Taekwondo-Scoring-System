   M S B A M L   `   `   `  ????I  ETaekwondoScore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TaekwondoScore.WindowsTaekwondoScore.Windows  5   	   (    "TaekwondoScore.Windows.TimerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TaekwondoScore.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? WindowStartupLocation$  CenterScreen=?5	   	    ? Title$ TimerWindow??5
   	   $	??350??6   $	??800??6*   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ??    SetTimebluebtn#??[  6   
????  ?$??+??6M    ? Cursor$
 Hand??6Z   ?? 5   
     SetTimeredbtn#??[ 6   $??1??68   
???  ??$??-??6V   ?? 5   
   $??1??6   $??2??6    
??? ???
???   ?$	??100(?6\   $??00:00??6k   $??	0 0 0 -50q?6{   ?? 5   
   -   5         ??Name$ setBtn??5      $??1??6!   $??1??61   $??2??6>   ???#00C500$	??SET??6g   $??DemiBold"?6u   $??40(?6?   $??20 70 20 20q?6?   6?   ?? 5   
   #??[  6   $??3??69   
????  ?$??+??6\   ?? 5    
   #??[ 6   $??3??69   $??1??6I   
???  ??$??-??6g   5#      5$      