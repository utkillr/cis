   M S B A M L   `   `   `  ����>  :CIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CISCIS  5   	       CIS.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   #localclr-namespace:CIS     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1200��6)    � DataContext$ 
MainWindow��5   	    � 	Resources 5	         CIS.BandsConverter   BandsConverter   CIS.GenresConverter  GenresConverter   CIS.RatingConverter  RatingConverter   CIS.LiveRatingConverter  LiveRatingConverter��%t   &	        &	      &	 &     &	 9       5
   
   6     5   
   6      5   
   6      5   
   6$   5      .��5      � $��0,0,0,45q�6   .+�5   
   �� -   5        $��Header��5      $
��Left=�6"   $��	10,10,0,0q�6=   $
��Wrap=�6P   $ ��Concert Information System��6d   $	��Top=�6�   $��32(�6�   $	��832��6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $��Register��5      $��Register��6!   $
��Left=�64   $��
847,10,0,0q�6O   $	��Top=�6c   $	��165��6{   $��43��6�   $��20(�6�   6�   �� 5   
   -   5        $��Login��5      $��
Check news��6   $
��Left=�63   $��1017,10,0,0q�6N   $	��Top=�6c   $	��165��6{   $��43��6�   $��20(�6�   6�   �� 5   
   -   5         ��Name$ 	SearchBox��5      $
��Left=�6%   $��29��6@   $��	79,75,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��897��6�   $��20(�6�   $��0��6�   �� 5   
   $��	Order by:��6   $
��Left=�6$   $��1017,75,0,0q�6?   $	��Top=�6T   $	��165��6l   $��29��6x   $��14(�6�   $
��Bold"�6�   $y�Hidden=�6�   �� 5   
   -   5        $��
OrderRadio��5      $
��Left=�6'   $��94��6B   $��1017,109,0,0q�6N   $	��Top=�6d   $	��165��6|   $y�Hidden=�6�   .+�5      	� $	��0,5q�6    	� 	GroupName$ order��6'   $��Rating��69    d� 	IsChecked$
 TrueY�6J   $��16(�6[   	� 5      $	��0,5q�6   $ order��6'   $��Live-Rating��69   $ FalseY�6O   $��16(�6a   	� 5      $	��0,5q�6   $ order��6'   $��Name-Rating��69   $ FalseY�6O   $��16(�6a   5      �� 5   
   -   5        $��EntityRadio��5      $
��Left=�6(   $��94��6C   $��847,109,0,0q�6O   $	��Top=�6d   $	��165��6|   $y�Hidden=�6�   .+�5      	� $	��0,5q�6   $ entity��6'   $��Bands��6:   $
 TrueY�6J   $��16(�6[   	� 5      $	��0,5q�6   $ entity��6'   $��Places��6:   $ FalseY�6K   $��16(�6]   	� 5      $	��0,5q�6   $ entity��6'   $��Concerts��6:   $ FalseY�6M   $��16(�6_   5      �� 5    
   $
��Left=�6   $��
10,109,0,0q�6.   $	��Top=�6B   $��86��6Z   $	��786��6f   ���	#00000000
���   ����	#FFEAEAEA.��5!      � $
��Left=�6   $��83��6.   $	��Top=�6:   $	��792��6R   $��
0,0,-18,-3q�6^   .+�5"      �� $
��Left=�6   $
��Wrap=�67   $Y��SHey, maybe you want to suggest something new?
Click to the right button to suggest!��6K   $	��Top=�6�   $��68��6�   $	��468��6�   $��20(�6�   $��0,15,0,0q�6�   �� 5#      -   5        $��PlaceButton��5#      $��Place��6,   $
��Left=�6<   $��
623,10,0,0q�6W   $	��Top=�6k   $	��150��6�   $��35��6�   $��20(�6�   6�   �� 5$      -   5        $��ConcertButton��5$      $��Concert��6.   $
��Left=�6@   $��
623,45,0,0q�6[   $	��Top=�6o   $	��150��6�   $��35��6�   $��20(�6�   6�   �� 5%      -	   5        $��GenreButton��5%      $��Genre��6,   $
��Left=�6<   $��
473,10,0,0q�6W   $	��Top=�6k   $	��150��6�   $��35��6�   $��20(�6�   6�   �� 5&      -
   5        $��
BandButton��5&      $
��Band��6+   $
��Left=�6:   $��
473,45,0,0q�6U   $	��Top=�6i   $	��150��6�   $��35��6�   $��20(�6�   6�   5'      5(      �� 5*   
   -   5         ��Name$ UpcomingConcertsList��5*      $
��Left=�6Y   $	��350��6t   $��
10,208,0,0q�6�   $	��Top=�6�   $	��370��6�   ��60   �� *UpcomingConcerts+��5+      �� 5,      .R�5-      �� -   5        ��5.      �� 5/      .R�50   "   �� $��5q�6)   $��1q�64   
�����F�	 �� CornerRadius$	 4��6`   $	��320��6q   ._�51   &   � $��3q�6+   
 � ColumnDefinitions
 52   *   �� 53   .   $	��100 �6?   �� 54   .   .+�56   *   �� $��2��60   $	��100��6A   $��75��6M   $��6q�6Y   ��6d   �� *
ImageURL+�� 57   *   $��1��65   $	��2,6q�6E   .+�58   .   �� $
��Bold"�68   ��6J   �� *Name+�� 59   .   ��68   �� *Date+ �� StringFormat$ {0:g}���� 5:   .   ��68   �� *Bands+ �� 	Converter# [  5;   +   5<   '   5=   #   5>      5@      5A      5C      �� 5D   
   
�������$��1q�6$   $��26��68   $
��Left=�6D   $��
10,195,0,0q�6_   $	��Top=�6s   $	��370��6�   $	 20��6�   
�������._�5E      �� $��Upcoming Concerts��6   $��	17,0,17,0q�60   $��1,3,1,1q�6C    J� RenderTransformOrigin$ 0.5,0.52&�6U   5F      �� 5H   
   -   5        $ 	BandsList��5H      $
��Left=�6C   $	��350��6^   $��411,208,0,0q�6k   $	��Top=�6�   $	��370��6�   ��6%   �� *Bands+��5I      �� 5J      .R�5K      �� -   5        ��5L      �� 5M      .R�5N   "   �� $��5q�6)   $��1q�64   
�����F�$	 4��6`   $	��320��6q   ._�5O   &   � $��3q�6+   
 5P   *   �� 5Q   .   $	��100 �6?   �� 5R   .   .+�5T   *   �� $��2��60   $	��100��6A   $��75��6M   $��6q�6Y   ��6d   �� *
ImageURL+�� 5U   *   $��1��65   $	��2,6q�6E   .+�5V   .   �� $
��Bold"�68   ��6J   �� *Name+�� 5W   .   ��68   �� *Genres+# [ �� 5X   .   ��68   �� *Rating+# [ �� 5Y   .   ��68   �� *
LiveRating+# [ 5Z   +   5[   '   5\   #   5]      5_      5`      5b      �� 5c   
   
�������$��1q�6$   $��26��68   $
��Left=�6D   $��411,195,0,0q�6_   $	��Top=�6t   $	��370��6�   $	 20��6�   
�������._�5d      �� $��Most Popular Bands��6   $��	17,0,17,0q�61   $��1,3,1,1q�6D   $ 0.5,0.52&�6V   5e      �� 5g   
   -   5        $ ConcertsList��5g      $
��Left=�6I   $	��350��6d   $��812,208,0,0q�6q   $	��Top=�6�   $	��370��6�   ��6(   �� *
Concerts+��5h      �� 5i      .R�5j      �� -   5        ��5k      �� 5l      .R�5m   "   �� $��5q�6)   $��1q�64   
�����F�$	 4��6`   $	��320��6q   ._�5n   &   � $��3q�6+   
 5o   *   �� 5p   .   $	��100 �6?   �� 5q   .   .+�5s   *   �� $��2��60   $	��100��6A   $��75��6M   $��6q�6Y   ��6d   �� *
ImageURL+�� 5t   *   $��1��65   $	��2,6q�6E   .+�5u   .   �� $
��Bold"�68   ��6J   �� *Name+�� 5v   .   ��68   �� *Date+$ g���� 5w   .   ��68   �� *Bands+# [  �� 5x   .   ��68   �� *Rating+# [ 5y   +   5z   '   5{   #   5|      5~      5      5�      �� 5�   
   
�������$��1q�6$   $��26��68   $
��Left=�6D   $��812,195,0,0q�6_   $	��Top=�6t   $	��370��6�   $	 20��6�   
�������._�5�      �� $��Most Popular Concerts��6   $��	17,0,17,0q�64   $��1,3,1,1q�6G   $ 0.5,0.52&�6Y   5�      �� 5�   
   $��Search:��6   $
��Left=�6"   $��	10,71,0,0q�6=   $	��Top=�6P   $��69��6h   $��18(�6s   �� 5�   
   -   5         ��Name$ 	SearchBtn��5�      $��GO��6$   $
��Left=�61   $��
976,75,0,0q�6L   $	��Top=�6`   $��36��6x   $��29��6�   6�   5�      5�      