   M S B A M L   `   `   `  ����E  ALibraryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LibraryWPF
LibraryWPF  5   	   "    LibraryWPF.CreateMovieWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=17.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LibraryWPF     5   	     � Title$  CreateMovieWindow��5	   	   $��540.912��6#   $��404.304��64    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ createMovieViewModel�.��5
      � $��	0,0,2,-63q�6    � ColumnDefinitions 5   
   �� 5      $
��218* �6   �� 5      $	��29* �6   �� 5      $
��147* �6   .+�5   
   �� $��Ajouter��6Y   $
��Left=�6k   $��20��6�   $��
29,478,0,0q�6�   $	��Top=�6�   $��83��6�   $��2��6�   y�6   �� *VisibilityAddBtn+��69   �� *CreateMovie+6�   �� 5   
   $��Modifier��6\   $
��Left=�6o   $��20��6�   $��
35,478,0,0q�6�   $	��Top=�6�   $��83��6�   y�6   �� *VisibilityUpdateBtn+��6<   �� *UpdateMovie+6�   �� 5   
   $��Titre:��6   $
��Left=�6!   $��	28,58,0,0q�6<   $	��Top=�6O   $��90��6g   �� 5   
   $��Genre:��6   $
��Left=�6!   $��
28,116,0,0q�6<   $	��Top=�6P   $��90��6h   �� 5   
   $��Sommaire��6   $
��Left=�6#   $��
28,179,0,0q�6>   $	��Top=�6R   $��90��6j   �� 5   
   $
��Left=�6   $	��121��6-   $��156,179,0,0q�6:    �� TextWrapping$
 Wrap=�6O   $	��Top=�6|   $	��203��6�   $��3��6�   ��6c   �� *	Summary+6�   �� 5   
   $
��Left=�6   $��26��6-   $��156,120,0,0q�69   $
 Wrap=�6N   $	��Top=�6y   $	��203��6�   $��3��6�   ��6b   �� *Genre+6�   �� 5   
   $
��Left=�6   $��156,58,0,489q�6-   $
 Wrap=�6C   $	��203��6n   $��3��6z   ��6W   �� *Title+6z   �� 5   
   $
��Left=�6(   $��46��6C   $��
28,427,0,0q�6O   $	��Top=�6c   $	��356��6{   $��3��6�   ��6   �� *Msg+6�   �� 5   
   $
��Left=�65   $��79��6P   $��156,327,0,0q�6\   $	��Top=�6q   $	��203��6�   $��3��6�   ��6   �� *	ErrorList+��5      �� 5      .R�5      � .+�5      �� ��6$   �� 5      5      5!      5"      5#      