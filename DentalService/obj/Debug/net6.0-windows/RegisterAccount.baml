   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DentalServiceDentalService  5   	   #    DentalService.RegisterAccount   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DentalService     5   	     � Title$  RegisterAccount��5   	   $	��400��5	   	   $	��600��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� $
��Auto=�6   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   $	��120��60   �� 5      $��* �6#   .+�5      �� $��Account Type:��6   $��0��5      $��0��5       $��Center=�5!      $��20(�5"      $��	0,0,10,10q�5#      �� 5$      -   5         ��Name$ AccountTypeComboBox��5$      $��0��5%      $��1��5&      $��Center=�5'      $��20(�5(      $��Stretch=�5)      $��0,0,0,10q�5*      .@�5+      ��  �� 
IsSelected$
 True��6   .��61   	Dentist6:   �� 5,      .��6   
Employee6)   �� 5-      .��6   
Customer6)   5.      �� 51      $��
Full Name:��6   $��1��52      $��0��53      $��Center=�54      $��20(�55      $��	0,0,10,10q�56      �� 57      -   5         ��Name$ NameTextBox��57      $��1��58      $��1��59      $��20(�5:      $��Stretch=�5;      $��0,0,0,10q�5<      �� 5?      $��Phone Number:��6   $��2��5@      $��0��5A      $��Center=�5B      $��20(�5C      $��	0,0,10,10q�5D      �� 5E      -   5        $ PhoneNumberTextBox��5E      $��2��5F      $��1��5G      $��20(�5H      $��Stretch=�5I      $��0,0,0,10q�5J      �� 5M      $��	Password:��6   $��3��5N      $��0��5O      $��Center=�5P      $��20(�5Q      $��	0,0,10,10q�5R      G� 5S      -   5         G�Name$ PasswordBox��5S      $��3��5T      $��1��5U      $��20(�5V      $��Stretch=�5W      $��0,0,0,10q�5X      �� 5[      $��Address:��6   $��4��5\      $��0��5]      $��Center=�5^      $��20(�5_      $��	0,0,10,10q�5`      �� 5a      -   5        $ AddressTextBox��5a      $��4��5b      $��1��5c      $��20(�5d      $��Stretch=�5e      $��0,0,0,10q�5f      �� 5i      $��Date of Birth:��6   $��5��5j      $��0��5k      $��Center=�5l      $��20(�5m      $��	0,0,10,10q�5n      (  "System.Windows.Controls.DatePicker  5o      -   5          Name$ BirthDatePicker��5o      $��5��5p      $��1��5q      $��20(�5r      $��Stretch=�5s      $��0,0,0,10q�5t      �� 5w      $��Register��6   $��6��5x      $��1��5y      $
��Left=�5z      $��20(�5{      $
��Bold"�5|      $
��10,5q�5}      $
��Auto��5~      $
��Auto��5      $��72,29,0,-10q�5�      5�      5�      5�      