   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DentalService.EmployeeDentalService.Employee  5      ,    &DentalService.Employee.EditAppointment   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:DentalService.Employee     5      $
��1200��5      $	��500��5	        � Title$  EditAppointment��5
      .��5      � 
�������.+�5   
   �� .+�5      �� $��Center=�6   $��Edit Appointment��65   $
��Bold"�6M   $��32(�6_   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��14 14 14 14q�6:   .+�5      �� $��Customer name��6$   $
��Bold"�69   $��14(�6L   $	��150��6Z   �� 5      $��	Test name��6$   $
��Bold"�65   $��14(�6H   $	��150��6V   5      �� 5      $ 
Horizontal=�6!   $��14 14 14 14q�6:   .+�5      �� $��Appointment Date��6$   $
��Bold"�6<   $��14(�6O   $	��150��6]   (  "System.Windows.Controls.DatePicker  5      6'   5      �� 5      $ 
Horizontal=�6!   $��	14 0 14 8q�6:   .+�5      �� $��Time Range:��6$   $
��Bold"�67   $��14(�6J   $	��150��6X   5       �� 5!      $ 
Horizontal=�6"   $��	50 0 14 8q�6;   .+�5"      �� $
��From��6$   $��14(�60   $	��116��6>   �� 5#      $��50��6#   ��6.   ��  �� Path$ HourList�6V   �� 5%      $�� : 00��6$   $��14(�62   $	��150��6@   5&      �� 5'      $ 
Horizontal=�6!   $��
50 0 14 14q�6:   .+�5(      �� $��To��6$   $��14(�6.   $	��116��6=   �� 5)      $��50��6I   ��6#   �� $ HourList�6V   �� 5*      $�� : 00��6$   $��14(�62   $	��150��6@   5+      �� 5,      $��
14 0 14 14q�6"   .+�5-      �� .+�5.      �� $
��Left=�6(   $��Dentist��6C   $
��Bold"�6R   $��14(�6e   $	��150��6s   �� 5/      $
��Left=�6(   $��36 8 0 0q�6�   $��14(�6�   $	��150��6�   ��6C   ��  �� ElementName$ DentistsDataGrid��$ SelectedItem� �� XPath$ DentistName��6�   50      51      �� 52      $��
14 0 14 14q�6"   .+�53      �� .+�54      �� $
��Left=�6(   $
��Time��6C   $
��Bold"�6O   $��14(�6b   $	��150��6p   �� 55      $
��Left=�6(   $��36 8 0 0q�6�   $��14(�6�   $	��150��6�   ��6C   �� $ DentistsDataGrid��$ SelectedItem�$ 	StartTime��6�   56      57      � 58      .+�59      �� $	��200��6!   $��24(�6-   $��	0 34 50 0q�6;   $��Right=�6O   
�������.��6�   Cancle6�   �� 5:      $	��200��6!   $��24(�6-   $��	50 34 0 0q�6;   $
��Left=�6O   
�������
������.��6�   Save6�   5;      5<      �� 5=      $��1��6   .+�5>      � .+�5?      �� $
��Left=�6$   $��Dentist Schedule:��6?   $
��Bold"�6X   $��14q�6j   $��14(�6v   $	��150��6�   �� 5@      $��Right=�6$   $��Search Name:��6@   $
��Bold"�6T   $��14q�6f   $��14(�6r   $	��200��6�   �� 5A      $��Right=�6"   $
��Bold"�6?   $��14q�6Q   $��14(�6]   $	��100��6k   5C      &   System.Windows.Controls.DataGrid  5D      -   5          Name$ DentistsDataGrid��5D         
IsReadOnly$
 True��69      AutoGenerateColumns$ False��6K   $��14 0 0 0q�6�   ��6g   �� $ DentistFreeTimeSchedule�	   Columns	 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Identifier��61      
FontFamily$ Arial)�6c      	FontStyle$ Italic$�6v      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	DentistId+6�     5G      $
 Dentist��61   $ Arial)�6b   $ Italic$�6u   $ * 6�    6B   �� *DentistName+6�     5H      $
 	Work Date��61   $ Arial)�6�   $ Italic$�6�   $ * 6�    6D   �� *
WorkingDay+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5I      $
 
Start Time��61   $ Arial)�6y   $ Italic$�6�   $ * 6�    6E   �� *
FreeHour+$ {0}:00��6�   5K      �� 5L      $0��**By default, every appointment take 1 hour��6   $��Italic$�6Q   $��16q�6d   5M      5N      5O      5P      5Q      