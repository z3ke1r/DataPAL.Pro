# DataPAL Pro

![DataPAL1](https://i.imgur.com/OSspjK1.png) ![DataPAL2](https://i.imgur.com/0UUCk7X.png)

## The Right Layer is Easy to Find
Where was that drainage basins layer? Was it this folder?....Nope...this one?...Nah...this folder has two which one is the updated one? 

Hate browsing through the catalog tree and countless sub folders to add a layer to the map? Or maybe you want to make sure your users are working with the proper managed data instead of a local copy that could be out of date.

Well!!! Check this add-in out!!

DataPAL can be used by any organization to give users the ability to quickly find and add layers to the active map. The backend crawls through a given directory and organizes them into an easy to browse UI. The user selects the layers they want clicks "Add", its that simple. The data library structure this app was built for consists of a single geodatabase that contains all of the feature datasets and thier respective feature classes. Then each feature class has a corresponding layer saved into a folder based on category i.e. '\\DataPAL\environmental', '\\DataPAL\transportation', '\\DataPAL\places'. However this can easily be modified to work with your environment. Dont want to use layers? It can be modified to use REST endpoints, shapefiles, feature classes etc. 

The UI utilizes [Material Design in XAML](http://materialdesigninxaml.net/) so the  - MD Themes package is required to use the UI elements like 'cards'.

Nuget Installation

    NuGet package manager: Install-Package MaterialDesignThemes
