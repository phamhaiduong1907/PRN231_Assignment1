   M S B A M L   `   `   `  ����E  AAss1Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Ass1Client.ViewAss1Client.View  5   	   '    !Ass1Client.View.OrderDetailWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Ass1Client.View     5   	   -   5          � Title$  OrderDetailWindow��5   	   $	��800��6#   .��5
      � 
����ح�.+�5   
   �� .+�5      �� $��Order Detail��6   $��20(�5      $
��Bold"�5      
���  ��$��Center=�5      �� 5       �� Orientation$ Vertical=�6   $��Center=�60   .+�5      �� $��
Order Date��6   $	��300��6-   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpkOrderDate��5      $��30��5      ${�False��5      �� 5      $��Required Date��6   $	��300��5        5      -   5        $ dpkRequiredDate��5      $��30��5      5      �� 5      -   5         ��Name$ panelAdminArea��5      .+�5      �� $��Shipped Date��6   $	��300��5        5      -   5        $ dpkShippedDate��5   !   $��30��5   !   5   !   �� 5      $��Freight��6   $	��300��5       �� 5!      -   5         ��Name$ 	tbFreight��5"      $��30��5!      5"      �� 5#      $ 
Horizontal=�6!   $��Center=�5$   !   .+�5%      �� -   5         ��Name$ btnUpdateOrder��5)   !   $
��Save��5%   !   $��30��5&   !   $��50��5'   !   $��10q�5(   !   5*   !   �� 5+      -   5        $ btnDeleteOrder��5/   !   $��Delete��5+   !   $��30��5,   !   $��50��5-   !   $��10q�5.   !   50   !   51      52      53      �� 54      $ Vertical=�6   $��Center=�55      .+�56      �� -	   5         ��Name$ lblProductId��58      $y�	Collapsed=�57      ��56      �� *	ProductId+ � DataContext 59      ��  �� Source %  System.Windows.Markup.Reference  *lvOrderDetails+	 �� Path$	 SelectedItem��� 5:      $��ProductName��6   $	��300��6.   �� 5;      -
   5        $ tbProductName��5<      
 �� 
IsReadOnly$

 True��5;      $��30��6,   ��5=      �� *ProductName+ 5>      ��    *lvOrderDetails+$	 SelectedItem��� 5?      $��Quantity��6   �� 5@      -   5        $ 
tbQuantity��5A      $��30��5@      ��5B      �� *
Quantity+ 5C      ��    *lvOrderDetails+$	 SelectedItem��� 5D      $��Discount��6   �� 5E      -   5        $ 
tbDiscount��5F      $��30��5E      ��5G      �� *
Discount+ 5H      ��    *lvOrderDetails+$	 SelectedItem��� 5I      $ 
Horizontal=�6   $��Center=�5J      .+�5K      �� -   5        $ btnUpdateDetail��5O      $��Update��5K      $��30��5L      $��70��5M      $��10q�5N      5P      �� 5Q      -   5        $ btnDeleteDetail��5U      $��Delete��5Q      $��30��5R      $��70��5S      $��10q�5T      5V      5W      5X      �� 5Y      -   5         ��Name$ lvOrderDetails��5Y      $	��200��5Z       �� View 5[      �� 5\      .P�5]      �� $��Product Name��6)    �� Width$	 200��5^   )    �� DisplayMemberBinding 5_   )   �� *ProductName+�� 5`      $��Quantity��6)   $	 100��5a   )    5b   )   �� *
Quantity+�� 5c      $��Discount��6)   $	 100��5d   )    5e   )   �� *
Discount+�� 5f      $��Price��6)   $	 100��5g   )    5h   )   �� *Price+5i      5k      �� 5l      $ 
Horizontal=�6   $��Center=�62   .+�5m      �� $��Total:��6   
���  ��$��20(�5n      $
��Bold"�6&   �� 5o      -   5        $ lblOrderValue��5o      $��20(�5p      $
��Bold"�5q      5r      5s      5t      5u      