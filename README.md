# 飯店網站
![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_52_49.png)

## 功能

* 飯店後台管理系統:
  * 
  
  
## 展示圖片 
##### 前端:
  1. 首頁 :
    #### 首頁功能:
      1. 顯示所有房號
  ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_52_49.png)
  
  2.  旅館介紹  :
    #### 旅館介紹功能:
      1. 預訂房間
  ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_53_14.png)
  
  3. 登入畫面:
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_53_21.png)
  
  4. 註冊會員:
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_10%20%E4%B8%8B%E5%8D%88%2004_12_19.png)
    
##### 後端:

  1. 民宿使用新增、更新、刪除(AJAX):
   ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_54_24.png)
   
  2. 民宿類別使用新增、更新、刪除(AJAX):
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_54_42.png)
       
  3. 訂單: 可以查看訂單
   ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_54_48.png)   
    
  2. 使用者(更改使用者權限):
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_54_55.png)  
     ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_55_08.png)  
    
  2. 使用者權限使用新增、更新、刪除(AJAX):
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_55_00.png)  
    
  2. 房號民稱使用新增、更新、刪除(AJAX):
    ![image](https://github.com/LiuYuJSCPPY/HotelManager/blob/main/Image/Hotelier%20-%20Hotel%20HTML%20Template%20-%20%E5%80%8B%E4%BA%BA%20-%20Microsoft%E2%80%8B%20Edge%202022_10_9%20%E4%B8%8B%E5%8D%88%2004_54_24.png) 

    
    
    
## 操作影片  


https://user-images.githubusercontent.com/73396015/194821059-7013ac70-c3e2-46b8-bf0b-650d70e61e6f.mp4



## 技術與工具
* 前端:
  * HTML5
  * CSS3
  * jquery
  * AJAX
  
* 後端:
   * ASP.NET MVC5:
     * Authentication
     * File
     
 * 資料庫:
    * SQLServer


## 資料表設計

 ![image](補
  * uesr : Laravel 內建的使用者資料表。
  * post : user_id 為 belong_to 與 user(id) 資料表做關聯 ，post_categroy_id 為 belong_to 與 post_categroy 資料表做關聯 ，artice_id 為 foreign key 與 Attractions 資料表做關聯。
  * post_categroy : post_categroy_id 為 has_Many 與 post_categroy 資料表做關聯。
  * comments : posts_id 為 belong_to 與 post 資料表做關聯，user_id 為 belong_to 與 user_id 資料表做關聯。
  * Attractions : 文章資料如: name、add、artice、display(bool)。
  * Attractions_img :Attractions_id 為 Foreign key 與 Attractions 資料表做關聯
  * Attractions_price :Attractions_id 為 Foreign key 與 Attractions 資料表做關聯
