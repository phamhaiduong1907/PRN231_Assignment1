   M S B A M L   `   `   `  ����  
Ass1Client"    Ass1Client.View.ReportWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ReportWindow��5   	   $	��800��6   .��5      � 
����ح�.+�5	   
   �� .+�5
      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ btnProfileNav��5      $��Profile��5      $��70��5      $��30��5      5      �� 5      -   5        $ btnOrderNav��5      $��Order��5      $��70��5      $��30��5      5      �� 5      -   5        $ btnProductNav��5      $��Product��5      $��70��5      $��30��5      5      �� 5      -   5        $ btnReportNav��5      $��Report��5      
�������
���  ��$��70��5      $��30��5      5      5       �� 5!      .+�5"      �� $��Report��6   $��20(�5#      
���  ��$��Center=�5%      $
��Bold"�5&      �� 5'      $ 
Horizontal=�6   $��Center=�5(      .+�5)      �� $��Start Date: ��6   (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ dpkStartDate��5*   !   $��0,0,50,0q�67   �� 5+      $��
End Date: ��6     5,      -   5        $ 
dpkEndDate��5,   !   $��0,0,50,0q�5-   !   �� 5.      -   5        $��Report��5.      $��70��6.   $��30��69   5/      50      51      �� 52      .+�53      �� $ 
Horizontal=�6   .+�54      �� -   5        $ 
btnRefresh��57      $��Refresh��54      $��70��55      $��30��56      58      59      �� 5:      -	   5         ��Name$ lvOrders��5:       �� View 5;      �� 5<      .P�5=      �� $��Email��6-    �� Width$	 200��5>   -    �� DisplayMemberBinding 5?   -   �� *Email+�� 5@      $��Shipped Date��6-   $	 100��5A   -    5B   -   �� *ShippedDate+ �� StringFormat$ {0:yyyy/MM/dd}���� 5C      $��Freight��6-   $	 100��5D   -    5E   -   �� *	Freight+�� 5F      $��Total Discount��6-   $	 100��5G   -    5H   -   �� *
Discount+�� 5I      $��Price��6-   $	 100��5J   -    5K   -   �� *Price+5L      5N      �� 5O      $ 
Horizontal=�6   .+�5P      �� $��Total Cost: ��6   $	��700��63   $��Right=�5Q      �� 5R      -
   5        	 ��Name$	 lblTotalCost��5T      $��Center=�5R      $	��100��5S      5T      5U      5V      5W      5X      5Y      