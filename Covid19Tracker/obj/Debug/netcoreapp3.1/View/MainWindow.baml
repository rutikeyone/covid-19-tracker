   M S B A M L   `   `   `  ����I  ECovid19Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Covid19TrackerCovid19Tracker  5   	   C&clr-namespace:Covid19Tracker.ViewModelCovid19Tracker.ViewModel  5   	       Covid19Tracker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Covid19Tracker     5   	   @mainviewmodel&clr-namespace:Covid19Tracker.ViewModel     5   	   -   5        $
��Main��5   	   $	��600��5
   	   $	��450��6     � WindowStartupLocation$  CenterScreen=�6"    � 
ResizeMode$ NoResize=�6G    � WindowStyle$
 None=�6]   ���	#FF4C1F6F � DataContext 5      ,   &Covid19Tracker.ViewModel.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��220 �6   �� 5      .+�5   
   �� $��0��6   .+�5      ��  �� Left$ 10��6]   
 �� Top$ 10��6n   $��40��6   $��35��6�   $��x��6�   $��16(�6�   ��6   �� *Close+��6/   ��  �� ElementName$
 Main��6�   5      �� 5   
   $��1��6   $%��/View/Resources/Covid19Icon.png��6   �� 5   
   $��2��6   
�������	 �� CornerRadius$	 10��61   $	��225��6C   $	��300��6P   ._�5      �� $��Center=�6   $��Center=�66   .+�5      �  5      �� 5      $
��auto �6(   68   �� 5       $
��60   �6(   69   �� 5!      $��50 �6(   66   �� 5"      $
��auto �6(   68    5$      �� 5%      $	��250 �6+   69   .+�5'      �� $��0��6\   ���	#FF4C1F6F$��DemiBold"�6�   $
��17.5(�6�   ��6   �� *	Country+
 �� UpdateSourceTrigger$
 PropertyChanged=�.��6�   5(      �� 5)      $
��37.5��6   $��1��6~   $��Get data by country name��6�   ��6+   �� *GetDataByCountry+��6P   �� $
 Main��6�   �� 5*      $
��37.5��6   $��2��6}   $��Get the total data��6�   ��6+   �� *GetTheTotalData+��6O   �� $
 Main��5+      �� 5,      $��3��6<   $��Medium"�6I   ���	#FF4C1F6F$��Center=�6t   ��6   �� *StatusValue+6t   5-      5.      5/      50      51      