   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DentalServiceDentalService  5   	   (    "DentalService.ManageMedicineScreen   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DentalService     5   	     � Title$  ManageMedicineScreen��5   	   $	��600��5	   	   $
��1100��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�5      $
��Left=�5      $	��Top=�5      $��10q�5      .+�5      �� -   5         ��Name$ btnAdd��5      $��Add new medicine��5      $��5q�5      $	��150��5      $��16(�5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgMedicines��5      $��1��6(   $��10q�65      AutoGenerateColumns$ False��6A      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Medicine ID��6%      
IsReadOnly$
 True��6Y   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6:   �� *
MedicineID+6Y     5"      $
 Name��6%   	 63   �� *MedicineName+  5#      $
 Unit��6%   	 63   �� *Unit+  5$      $ Prescription��6%   	 6;   �� *Prescription+  5%      $ Quantity��6%   	 67   �� *QuantityOnStock+  5&      $ Expiration Date��6%   	 6>   �� *ExpirationDate+  5'      $ Price��6%   	 64   �� *Price+  5(      $ Description��6%   	 6:   �� *Description+4  .System.Windows.Controls.DataGridTemplateColumn  5*      $ Delete��6)   
   CellTemplate
 5+      �� 5,      .R�5-      �� $ 	btnDelete��6%   -   5        $��Delete��5-   8   $��10q�6a   5.      50        52      $ Update��6)   
 53      �� 54      .R�55      �� $ 	btnUpdate��6%   -   5        $��Update��55   8   $��10q�6a   56      58      5;      �� 5=   
   $��2��6   $ 
Horizontal=�5>      $
��Left=�5?      $��Bottom=�5@      $��10q�5A      .+�5B      �� $��Expired Medicines:��6   $��5q�61   �� 5C      -   5         ��Name$ lbExpiredMedicines��5C      $	��200��62   $	��100��6>   $��5q�6K   ��5D      �� 5E      .R�5F      �� .+�5G      �� ��5H   "   `� 5I   &    �� StringFormat$ 	{0} - {1}��63   .1�5J   *   ��  �� Path$ MedicineName�62   �� 5K   *   $ QuantityOnStock�62   5L   '   5N      5O      5P      5R      �� 5T      -   5        $ btnDeleteExpired��5T      $��Delete Expired��5U      $��5q�5V      $	��120��5W      $��35��5Y      5Z      5[      5\      