# Create Multiple Publish Profiles in Asp.Net Core
## Steps: 
1. Right-click on the application in Solution Explorer, and click Publish.
2. The Publish screen will open.
3. Click on New Profile.
4. Select Folder, choose a folder path, and click Finish.
5. A new Publish Profile will be created. Rename the Publish Profile as needed.
6. The Publish Profile creation is now complete. Click on the Publish button to generate a build.
7. To set the environment for this Publish Profile, add the following line inside the `<PropertyGroup>` section of the `.pubxml` file:

```xml
<PropertyGroup>
  ...
<EnvironmentName>Production</EnvironmentName>
</PropertyGroup>
```

