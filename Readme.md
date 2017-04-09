**Project modification**

1. In *VideoStore.Entities/VideoStore.Business.Entities/VideoStoreEntitModel.edmx*
    - Add entity model *Review*.
    - Add relationship *UserReview*.
    - Add relationship *MediaReview*.
    - Add property *Country* and *City* in entity *User*.
    - Update sql file*VideoStore.Entities/VideoStore.Business.Entities/VideoStoreEtityModel.edmx.sql*.

2. In *VideoStore.Services.MessageTypes/User.cs*,*VideoStore.WebClient/ViewModels/EditUserDetailsViewModel.cs* and *VideoStore.WebClient/ViewModels/RegistrationViewModel.cs*
    - Add property *Country* and *City*.

3. In *VideoStore.WebClient/Views/Account/Register.cshtml* and*VideoStore.WebClient/Views/Manage/UpdateUser.cshtml*
    - Add form field *Country* and *City*.

4. In *VideoStore.WebClient/Controllers/StoreController.cs*
    - Add action *WriteReview* and *MediaDetail*.

5. In *VideoStore.Business.Components.Interfaces/ICatalogueProvider.cs*, *VideoStore.Business.Components/CatalogueProvider.cs*, *VideoStore.Services/CatalogueService.cs* and *VideoStore.Services.Interfaces/ICatalogueService.cs*
    - Add operation *GetReviews* and *CreateReview*.

6. In *VideoStore.Services/MessageTypeConverter.cs*
    - Add mappers between *Business.Entities.Review* and *VideoStore.Services.MessageTypes.Review*.

7. In *VideoStore.WebClient/Views/Store/ListMedia.cshtml*
    - Add href on media title to deatil page.

8. Add new files:
    - VideoStore.Services.MessageTypes/Review.cs
    - VideoStore.WebClient/ViewModels/WriteReviewViewModel.cs
    - VideoStore.WebClient/Views/Store/WriteReview.cshtml
    - VideoStore.WebClient/ViewModels/MediaDetailViewModel.cs
    - VideoStore.WebClient/Views/Store/MediaDetail.cshtml

**Run project**

1. Open *ViewdStore.sln* in VisualStudio 2015.
2. Create local database:
    1. Click on Tools > SQL Server > New Query.
    2. Expand “Local” on the dialog that shows up, select *MSSQLLocalDb*, and then click connect.
    3. Type in `create database Videos;` on the sql file that appears.
    4. Execute this by click on SQL > Execute.
3. Create database scheme:
    1. Open file *VideoStore.Business/VideoStore.Business.Entities/VideoStoreEntityModel.edmx.sql*.
    2. Click on SQL > Execute. Expand “Local” on the dialog that shows up, select *MSSQLLocalDb*, and then click connect.
4.  Start the application server by right click on the *VideoStore.Application/VideoStore.Process* project and click Debug > Start New Instance.
5.  Start the web server by right click on the *VideoStore.Presentation/VideoStore.WebClient* project and click Debug > Start New Instance. This should start a browser that takes you to the VideoStore login page.
