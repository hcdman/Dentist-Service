   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DentalService.EmployeeDentalService.Employee  5   	   +    %DentalService.Employee.EmployeeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DentalService.Employee     5   	     � Title$  EmployeeWindow��5   	   $	��600��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1q�6   
���   �
���iii�._�5      � $��	16 8 16 8q�6   $��32��6'   .+�5      �� -   5        $	��120��5      
�������$��16 0 0 0q�6T   $��Right=�6f   $��Logout��6�   �� 5      $��20(�6   
������ $��16 0 0 0q�6D   $��Center=�6V   $��Employee��6s   5      5      � 5   
   
�������$��1��6"    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��1q�6   
���   �._�5      � $��0��6   $��8 8 8 8q�6'   .+�5       �� .+�5!      �� $��Center=�6$   $��24(�6A   $��0 0 0 14q�6O   
Employee6k   �� 5"       �� Orientation$ 
Horizontal=�6%   .+�5#      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Full name: ��6V   �� 5$      $��Medium"�6(   $��14(�6<   ��6J   ��  �� Path$ Customer.FullName�5%      �� 5&      $ 
Horizontal=�6%   $��0 8 0 8q�6>   .+�5'      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Birth Date: ��6V   �� 5(      $��Medium"�6(   $��14(�6<   ��6J   �� $ Customer.Birthday�5)      �� 5*      $ 
Horizontal=�6%   .+�5+      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Phone: ��6V   �� 5,      -   5         ��Name$ CustomerPhoneTextBox��5,   &   $��14(�6D   $	��180��6R   $��Medium"�6a   6u   5-      �� 5.      $ Vertical=�6%   $��0 56 0 0q�6<   .+�5/      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��New Customer? ��6V   �� 50      $��5q�6%   $	��120��60   
������
�������$��32��6h   .��6t   Create Account6�   51      52      53      54      �� 57      $��Hidden=�6   $��1��6@   .��58      �� $��0��6   
���   �$��1q�6:   ._�59      � $��8 8 8 8q�6   .+�5:      �� .+�5;      �� $��Center=�6(   $��24(�6E   $��0 0 0 14q�6S    Customer Upcomming Appointment6�   &   System.Windows.Controls.DataGrid  5D      -   5        $��CustomerAppoitment��5D   '      
IsReadOnly$
 True��6A      AutoGenerateColumns$ False��6S   	   Columns	 5E   "   0  *System.Windows.Controls.DataGridTextColumn  5F   &   ,  &System.Windows.Controls.DataGridColumn
   Header$
 Appointment Date��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6]   �� *AppointmentDate+  5G   &   $
 
Start Time��69   $ * 6M    6W   �� *	StartTime+  5H   &   $
 End Time��69   $ * 6K    6U   �� *	EndTime+  5I   &   $
 Status��69   $ * 6I    6S   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5J   &      CellTemplate 5K   *   �� 5L   .   .R�5M   2   ��  ��Name$ UpdateAp��69   -   5        $��Update��5M   i   
 � Tag 6K   �� *AppointmentId+6z   5N   /   5P   '   5R      �� 5S      $��0 8 0 8q�6(   6;   �� 5U      $ 
Horizontal=�6)   $��Right=�6B   .+�5V   "   �� -   5        $��CreateAppointmentButton��5V   )   $	��130��6H   ${�False��6T   $��32��6�   .��6�   Create6�   4  .System.Windows.Controls.Ribbon.RibbonSeparator  5W   "   $��8q�62   5Y      �� 5[      $��	0 20 0 20q�6(   $��2q�6;   
���   �6e   �� 5]      $��Center=�6(   $��24(�6E   $��0 0 0 14q�6S   Unpay Treatement6w     5^      $ False��6(   ��6;   �� $ UnpayTreatment�	 5_   "     5`   &   $
 Dentist��69   $ * 6J     5a   &   $
 Appointment Date��69   $ * 6S     5b   &   $
 Appointment Time��69   $ * 6S   5d      �� 5e      $��0 8 0 8q�6(   6;   �� 5g      $ 
Horizontal=�6)   $��Right=�6B   .+�5h   "   �� -   5        $	��130��5h   )   $��32��6Q   .��6]   Take Payment6k   5j      5k      5l      5m      5n      5o      5p      5q      