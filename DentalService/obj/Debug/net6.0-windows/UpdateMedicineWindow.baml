   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DentalServiceDentalService  5   	   (    "DentalService.UpdateMedicineWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DentalService     5   	     � Title$  UpdateMedicineWindow��5   	   $	��750��5	   	   $	��800��5
   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Medicine Name��6   $��0��6(   $��5q�65   $��16(�6@   �� 5   
   -   5         ��Name$ txtMedicineName��5      $��1��6+   $��5q�68   $��16(�6C   �� 5    
   $
��Unit��6   $��2��6   $��5q�6,   $��16(�67   �� 5!   
   -   5        $ txtUnit��5!      $��3��6#   $��5q�60   $��16(�6;   �� 5#   
   $��Prescription��6   $��4��6'   $��5q�64   $��16(�6?   �� 5$   
   -   5        $ txtPrescription��5$      $��5��6+   $��5q�68   $��16(�6C   �� 5&   
   $��Quantity��6   $��6��6#   $��5q�60   $��16(�6;   �� 5'   
   -   5        $ txtQuantity��5'      $��7��6'   $��5q�64   $��16(�6?   �� 5)   
   $��Expiration Date��6   $��8��6*   $��5q�67   $��16(�6B   (  "System.Windows.Controls.DatePicker  5*   
   -   5          Name$ dpExpirationDate��5*      $��9��6/   $��5q�6<   �� 5,   
   $��Price��6   $��10��6    $��5q�6.   $��16(�69   �� 5-   
   -   5        $ txtPrice��5-      $��11��6$   $��5q�62   $��16(�6=   �� 5/   
   $��Description��6   $��12��6&   $��5q�64   $��16(�6?   �� 50   
   -   5        $ txtDescription��50      $��13��51      $��5q�52       �� TextWrapping$
 Wrap=�53       �� AcceptsReturn$
 True��54      $	��100��55      $��16(�56      �� 58   
   -   5        $��Update Medicine��58      $��14��59      $��0,5,0,5q�5;      $��Center=�5<      $
��10,5q�5=      $	��200��5>      $��50��5?      $��20(�5@      $
��Bold"�5A      5B      5C      