   M S B A M L   `   `   `  ����T  PBankManagement_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:BankManagement_Assignment.viewBankManagement_Assignment.view  5      +    %BankManagement_Assignment.view.query1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:BankManagement_Assignment.view     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  query1��5
      .��5      � $��1��6   $	��824��6    � RowDefinitions 5   
   �� 5      $	��100 �6   6,   �� 5      $��* �6   6*   .+�5   
   � $��0��6   ���	#FFFAFAFA$	��Top=�63   $	��100��6K    K� ZIndex$ 10��6X   .+�5      �� $��Center=�6   $��Center=�65    $   MaterialDesignHeadline4TextBlock#��[  6P   查询6�   5      � 5   
   $��1��6   $��10q�6   .+�5      � $	��Top=�6   $��30��6+    � ColumnDefinitions 5      �� 5      $
��173* �6'   �� 5      $
��631* �6'   .+�5      �� -   5         ��Name$ Textbox��5      $	��200��6+   $��	119,0,0,6q�67     MaterialDesignTextBox#��[ 6J   $��Center=�6{   $
��Left=�6�   $��1��6�   �� 5      -   5         ��Name$ QueryTypeBox��5      $��0,-15,584,0q�61   $	��200��6G   $	��Top=�6S   $��Right=�6k   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 查询方式��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .   & "MaterialDesignFloatingHintComboBox#��[ 6�   $��2��6  .@�5      �� .��6#   账号5      �� 5      .��6#   	身份证5       5!      (  "System.Windows.Controls.DatePicker  5"      -   5          Name$ datePickerBirthDate��5"      $
��Left=�6:   $��100,187,0,-157q�6U   $	��Top=�6m   $	��115��6�   $��2��6�   �� 5#      -   5        $��Right=�5#      $��	0,-3,20,1q�65     MaterialDesignRaisedButton#��[ 6H   $��查询��6|   $��1��6�     5$      -   5        $��dp��5$      $
��Left=�6'   $��	373,0,0,0q�6B   $	��Top=�6U   $	��152��6m   $��1��6y   5%      �� 5&      -   5        $��ListBox��5&      $��-10,30,10,0q�6&   ��6;   �� *.+	 �� View	 5'      �� 5(      -   5        	Gridview1��.P�5)      �� 
 �� Width$
 80��6)   -   5        Account_Column��$��账号��5)   M    �� DisplayMemberBinding 6Y   �� *
Account_ID+6�   �� 5*      $	
 150��6)   -	   5        ID_Colum��$��	身份证��5*   G    6X   �� *	ID_Number+6�   �� 5+      $
 86��6)   -
   5        
Type_Colum��$��账户类型��5+   I    6Z   �� *Account_Type+6�   �� 5,      $
 80��6)   -   5        
Name_Colum��$��姓名��5,   I    6Y   �� *Name+6�   �� 5-      $
 80��6)   -   5        Money_Colum��$��余额��5-   J    6Y   �� *Money+6�   �� 5.      $
 87��6)   -   5        OperationType_Colum��$��交易类型��5.   R    6c   �� *Operation_Type+6�   �� 5/      $	
 200��6)   -   5        Trading_Time_Colum��$��交易时间��5/   R    6c   �� *Trading_Time+6�   50      52      53      56      57      