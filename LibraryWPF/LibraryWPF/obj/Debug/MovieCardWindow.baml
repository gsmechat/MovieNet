   M S B A M L   `   `   `  ����E  ALibraryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LibraryWPF
LibraryWPF  5   	       LibraryWPF.MovieCard   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=17.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LibraryWPF     5   	     � Title$  	MovieCard��5	   	   $��600.555��6   $��843.442��6,    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$ movieCardViewModel�.��5
      � $��
0,0,16,-31q�6   .+�5   
   �� $��Center=�60   $��46��6M   $��190,10,142,0q�6Y   $	��Top=�6o   $	��487��6�   $��20(�6�   $
��Bold"�6�   $��Center=�6�   ��6   �� *Movie.Title+6�   �� 5   
   $��Genre: ��6   $
��Left=�6"   $��27��6=   $��	20,70,0,0q�6I   $	��Top=�6\   $��54��6t   $
��Bold"�6   �� 5   
   $��
Résumé: ��6   $
��Left=�6#   $��27��6>   $��
20,102,0,0q�6J   $	��Top=�6^   $��65��6v   $
��Bold"�6�   �� 5   
   $
��Left=�60   $��	90,70,0,0q�6K   $	��Top=�6^   $��25��6v   $	��212��6�   ��6   �� *Movie.Genre+6�   �� 5   
   $��Avis: ��6   $
��Left=�6!   $��27��6<   $��
20,280,0,0q�6H   $	��Top=�6\   $��65��6t   $
��Bold"�6   �� 5   
   $
��Left=�6^   $	��113��6y   $��
90,312,0,0q�6�   $	��Top=�6�   $	��715��6�    J� RenderTransformOrigin$ 0.28,0.5&�6�   ��6   �� $ AvisList� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      � .+�5      �� ��6$   �� *Note+�� 5      $
��/10 ��6$   �� 5      ��6$   �� *Commentaire+5      5      5      �� 5   
   $��Ajouter un commentaire��60   $
��Left=�6Q   $��32��6l   $��654,515,0,0q�6x   $	��Top=�6�   $	��151��6�   $ 
-0.067,0.5&�6�   ��6   �� *
AddComment+6�   �� 5"   
   $��Note: ��6   $
��Left=�6!   $��27��6<   $��
90,483,0,0q�6H   $	��Top=�6\   $��65��6t   $
��Bold"�6   �� 5#   
   $��Commentaire: ��6   $
��Left=�6(   $��27��6C   $��190,483,0,0q�6O   $	��Top=�6d   $��95��6|   $
��Bold"�6�   �� 5$   
   $
��Left=�6.   $��32��6I   $��190,515,0,0q�6U    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��428��6�   ��6   �� *
CommentAdd+6�   �� 5%   
   $
��Left=�6+   $��32��6F   $��
90,515,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $��66��6�   ��6   �� *	NoteAdd+6�   �� 5(   
   $
��Left=�65   $��42��6P   $��571,444,0,0q�6\   $	��Top=�6q   $	��234��6�   ��6   �� *	ErrorList+��5)      �� 5*      .R�5+      � .+�5,      �� ��6$   �� 5-      5.      50      �� 51   
   $
��Left=�61   $	��184��6L   $��
90,102,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��715��6�   ��6   �� *Movie.Summary+6�   55      56      