   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DentalService.EmployeeDentalService.Employee  5      $    DentalService.Employee.Invoice   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:DentalService.Employee     5      $	��600��5      $	��800��6     � Title$  Invoice��5	       � DataContext 5
      ��  �� RelativeSource �� *Self+.��5      � 
�������.+�5   
   �� .+�5      �� $��Center=�6   $��INVOICE��65   $
��Bold"�6D   $��32(�6V   �� 5      .+�5      �� $��Customer Name��6   $
��Bold"�61   $��14(�6C   $��8 16 8 0q�6Q   �� 5      -   5        $��CustomerNameTextBox��5      $
��Bold"�68   $��	Test Name��6J   $��14(�6[   $��	32 0 32 0q�6i   5      �� 5      .+�5      �� $��Dental Service��6   $
��Bold"�62   $��14(�6D   $��8 16 8 0q�6R   &   System.Windows.Controls.DataGrid  5      -   5          Name$ ServiceDataGrid��5      $��	32 0 0 0 q�64      
IsReadOnly$
 True��6G      AutoGenerateColumns$ False��6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6-      
FontFamily$ Arial)�6[   	   	FontStyle$	 Italic$�6n   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ServiceName+6�     5      $ Quantity��6-   $ Arial)�6`   $	 Italic$�6s   $
 * 6�    6?   �� *SoldQuantity+6�     5      $ Price��6-   $ Arial)�6V   $	 Italic$�6i   $
 * 6}    6<   �� *Price+6}   5      5      �� 5       .+�5!      �� $��Medicine��6   $
��Bold"�6,   $��14(�6>   $��8 16 8 0q�6L     5"      -   5        $ MedicineDataGrid��5"      $��32 0 0 0q�66   $
 True��6H   $ False��6Z    5#        5%      $
 Name��6-   $ Arial)�6\   $	 Italic$�6o   $
 * 6�    6;   �� *MedicineName+6�     5&      $ Quantity��6-   $ Arial)�6`   $	 Italic$�6s   $
 * 6�    6?   �� *SoldQuantity+6�     5'      $ Price��6-   $ Arial)�6V   $	 Italic$�6i   $
 * 6}    6<   �� *Price+6}   5)      5*      �� 5+      .+�5,      �� $��Examination Fee��6   $
��Bold"�63   $��14(�6E   $��8 16 8 0q�6S   �� 5-      -   5        $��ExaminationFeeTextBlock��5-      $
��Left=�6<   $��14(�6W   $��	32 0 32 0q�6e   5.      �� 5/      .+�50      �� $��Total Payment��6   $��24(�61   $��8 16 8 0q�6?   �� 51      -   5        $��TotalPaymentTextBlock��51      $
��Left=�69   $��24(�6T   $��	32 0 32 0q�6b   52      �� 53      $��Take Payment��6   $��20(�6,   
�������$	��200��6Q   $��Right=�6]   $��	0 16 16 0q�6y   54      55      56      