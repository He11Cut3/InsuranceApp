   M S B A M L   `   `   `  ����G  CInsuranceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InsuranceApp.CliInsuranceApp.Cli  5   	   !    InsuranceApp.Pol.Edit_Polic   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InsuranceApp.Cli     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  66     � Title$
  Main��5   	   $	��530��5	   	   $	��780��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ .��5      �  � ColumnDefinitions 5   
   �� 5      $	��370 �6   �� 5      $	��410 �6   �� 5      $��0* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��31* �6   �� 5      $��8* �6   .+�5   
   � $��3��6   $��2��5      .+�5      ��  �� CornerRadius$ 10 10 10 10��6   $��2��5       ���#1b97f3   MaterialDesignPaper#���   5"      $��1q�5#      5%      5'      �� 5+   
   $��0��6   $��1q�5,      $��15,15,15,15q�5-      $ 15��5.      $��2��5/      55      �� 58   
   $��1��6   $��1q�59      $ 15��5:      $��
54,0,54,20q�5;      $��2��5<      $��2��5=      ��5>      �� 5?       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�5@   "   5A      5D      �� 5E   
   $��1��6   $��1��5F      $��2��5G      .+�5H      �� -   5        	 ��Name$	 Number��5H      $	��200��5I        MaterialDesignBody#���  5J      $��35��5K      $��	45 25 5 0q�5L      $
��Left=�5M      $��
Montserrat)�5N      $��Medium"�5O      $��16(�5P      
 �� 	MaxLength$
 40��5Q      �� 5S      -   5         ��Name$
 Type��5[      $	��200��5S      #���  5T      $��35��5U      $��	45 25 5 0q�5V      $
��Left=�5W      $��
Montserrat)�5X      $��Medium"�5Y      $��16(�5Z      .@�5]      �� $'��!Страхование жизни��6   �� 5^      $5��/Страхование недвижимости��6   �� 5_      $/��)Страхование имущества��6   �� 5`      $3��-Автомобильная страховка��6   5b      (  "System.Windows.Controls.DatePicker  5c      -   5          Name$ DateS��5c      $	��200��5e      #���  5f      $��35��5g      $��
45 15 0 10q�5h      $
��Left=�5i      $��
Montserrat)�5j      $��Medium"�5k      $��16(�5l        5m      -   5        $ DateDo��5m      $	��200��5o      #���  5p      $��35��5q      $��45 15 15 10q�5r      $
��Left=�5s      $��
Montserrat)�5t      $��Medium"�5u      $��16(�5v      �� 5x      -   5        $ Status��5�      $	��200��5x      #���  5y      $��35��5z      $��	45 25 5 0q�5{      $
��Left=�5|      $��
Montserrat)�5}      $��Medium"�5~      $��16(�5      .@�5�      �� $��Активный��6   �� 5�      $��Аннулирован��6   �� 5�      $ ��Приостановлен��6   �� 5�      $��Исполнен��6   �� 5�      $C��=Отменено по запросу страхователя��6   5�      5�      �� 5�   
   $��1��6   $��0��5�      $��2��5�      .+�5�      �� $��
Номер��6     	Button_LV#��[ 5�      $��22��5�      $��	30,35,0,0q�5�      $	��138��5�      �� 5�      $��Тип��6   #��[ 5�      $��22��5�      $��	30,35,0,0q�5�      $	��138��5�      �� 5�      $!��Действителен с��6   #��[ 5�      $��22��5�      $��	30,35,0,0q�5�      $	��138��5�      �� 5�      $
��До��6   #��[ 5�      $��22��5�      $��	30,35,0,0q�5�      $	��138��5�      �� 5�      $��Статус��6   #��[ 5�      $��22��5�      $��	30,35,0,0q�5�      $	��138��5�      5�      �� 5�   
   -   5         ��Name$ 	Edit_Pols��5�      $��1��5�      $��2��5�      $��Right=�5�      $��35��5�      $��Medium"�5�      $	��100��5�      $��
Montserrat)�5�      $��Изменить��5�      $	��Top=�5�      $��15,25,65,15q�5�      �� 5�   
   $��0��6   $��1q�5�   	   $��15,15,15,15q�5�   	   $ 15��5�   	   $��2��5�   	   ._�5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�      �� $��С.К. - Согласие��6   #��[ 5�      $��20(�5�      $��
Montserrat)�5�      $��Medium"�5�      $��Center=�5�      $��10,0,0,0q�5�      �� 5�      -   5        $ ComeBack��5�        MaterialDesignIconButton#��[ 5�      
�������$��40��5�      $
��Left=�5�      $��1��5�      $��	570,0,0,0q�5�      .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ LogoutVariant=�6.   5�      5�      5�      5�      5�      