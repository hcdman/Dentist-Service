   M S B A M L   `   `   `  ����H  DDentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DentalServiceDentalService  5   	       DentalService.Admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DentalService     5   	     � Title$  Admin��5   	   $
��Auto��5	   	   $
��Auto��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5   	   ���#F5F5F5 � 	Resources 5         ModernButton �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%^  &	        �� 5   
   " ��6%   .�5      ��  � �� �#4A90E26+   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6(    5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      ��  � �� �#2E4C7B63   5      5      5      .��5      � $��20q�6   
 � RowDefinitions
 5   
   �� 5       $
��Auto �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $
��Auto �6    � ColumnDefinitions 5&   
   �� 5'      $��* �6   �� 5(      $��* �6   .+�5,   
   �� $��Admin Dashboard��6   $��2��5-      $��Center=�5.      $	��Top=�5/      $��30(�50      $
��Bold"�51      $��	0,20,0,20q�52      ���#2E4C7B53      �� 56   
   $��0��57      $��1��58      $��Right=�59      $��	0,20,20,0q�5:      $	��Top=�5;      $
��Bold"�5<      $��16(�5=      ���#4A90E2��56      �� *
UserName+5>      �� 5A   
   -   5        $��Medicine Management��5A      $��1��5B      $��1��5C      $��0,27,0,0q�5D      $	��Top=�5E      $��Center=�5F      $	��212��5G      $��50��5H      #��[  5I      $��2��5J   6   �� 5L   
   -   5        $��Delete Users��5L      $��2��5M      $��0,75,0,0q�5N      $	��Top=�5O      $��Center=�5P      $	��200��5Q      $��50��5R      #��[  5S       J� RenderTransformOrigin$ 
0.514,0.87&�5T   3   �� 5V   
   -   5        $��Create new account��5V      $��0,2,0,0q�5W      $	��Top=�5X      $��Center=�5Y      $	��200��5Z      $��50��5[      #��[  5\      $��2��5]   5   �� 5^   
   -   5        $��Logout��5^      $��2��5_      $��1��5`      $
��Left=�5a      $��203,115,0,0q�5b      $	��Top=�5c      $��67��5d      $��30��5e      $��2��5f   .   5g      5h      