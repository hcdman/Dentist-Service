   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DentalServiceDentalService  5   	       DentalService.Customer   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DentalService     5   	     � Title$  Customer��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1q�6   
���   �
���iii�._�5      � $��	16 8 16 8q�6   $��32��6'   .+�5      �� -   5        $	��120��5      
�������$��16 0 0 0q�6T   $��Right=�6f   $��Logout��6�   �� 5      $��20(�6   
������ $��16 0 0 0q�6D   $��Center=�6V   $��Customer��6s   5      5      � 5   
   
�������$��1��6"    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��1q�6   
���   �._�5      � $��0��6   $��8 8 8 8q�6'   .+�5       �� .+�5!      �� $��Center=�6$   $��24(�6A   $��0 0 0 14q�6O   Customer Infomation6v   �� 5"       �� Orientation$ 
Horizontal=�6%   .+�5#      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Full name: ��6V   �� 5$      $��Medium"�6(   $��14(�6<   ��6J   �� *
FullName+5%      �� 5&      $ 
Horizontal=�6%   $��0 8 0 8q�6>   .+�5'      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Birth Date: ��6V   �� 5(      $��Medium"�6(   $��14(�6<   ��6J   �� *
Birthday+ �� StringFormat$ 
dd-MM-yyyy��5)      �� 5*      $ 
Horizontal=�6%   .+�5+      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $��Phone: ��6V   �� 5,      $��14(�6&   $��Medium"�64   ��6H   �� *PhoneNumber+5-      �� 5.      $ Vertical=�6%   $��0 56 0 0q�6<   .+�5/      �� $��Medium"�6(   $��14(�6<   $	��100��6J   $�� ��6V   �� 50      $��5q�6%   $	��120��60   
������
�������$��32��6h   .��6t   Create Appointment6�   51      52      53      54      �� 57      $��Hidden=�6   $��1��6@   .��58      �� $��0��6   
���   �$��1q�6:   ._�59      � $��8 8 8 8q�6   .+�5:      �� .+�5;      �� $��Center=�6(   $��24(�6E   $��0 0 0 14q�6S    Customer Upcomming Appointment6�   &   System.Windows.Controls.DataGrid  5<         
IsReadOnly$ False��6(   ��6;   ��  �� Path$ UpcommingAppointmentList�   Columns 5=   "   0  *System.Windows.Controls.DataGridTextColumn  5>   &   ,  &System.Windows.Controls.DataGridColumn	   Header$	 Dentist��69   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6J     5?   &   $	 Appointment Date��69   $
 * 6S     5@   &   $	 Appointment Time��69   $
 * 6S   5B      �� 5C      $��0 8 0 8q�6(   6;   �� 5E      $ 
Horizontal=�6)   $��Right=�6B   .+�5F   "   �� -   5        $	��130��5F   )   $��32��6U   .��6a   Create6i   4  .System.Windows.Controls.Ribbon.RibbonSeparator  5G   "   $��8q�62   �� 5H   "   -   5        $	��130��5H   )   $��32��66   .��6`   Edit6f   5I      �� 5K      $��	0 20 0 20q�6(   $��2q�6;   
���   �6e   �� 5M      $��Center=�6(   $��24(�6E   $��0 0 0 14q�6S   Medical Records6v     5N      -   5        $��recordsTable��5N   :   $ False��6'      AutoGenerateColumns$ False��6u   ��6N   �� *MedicalRecords+ 5O   "     5P   &   $	 Dentist��69   $
 * 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *DentistName+  5Q   &   $
	 Date��69   $
 * 6G    6Q   �� *MedicalRecordDate+$ 
dd-MM-yyyy��  5R   &   $		 Fee��69   $
 * 6F    6P   �� *Description+5T      5U      5V      5W      5X      5Y      5Z      5[      