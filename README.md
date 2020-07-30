# Enemy Paths

A unity package which allows the user to create, alter and visualise enemy paths within the editor.

## Installation

Install this package through one of the following ways:
- Clone this repository and add it to your Unity project as a local package by selecting the `package.json`.
- Directly add this repository to your Unity project as a git package by using the git url.

#### Additional required dependency:
- Odin Inspector

## Usage

### Fields
- **Waypoints**: List of waypoints to create the path from.
- **Fix Y Axis**: Determines if the Y axis should be locked.
- **Handle Visualisation**: Determines if the handles are shown as arrow handles or free move handles.
- **Path Color**: The color of the path.
- **Path Visibility**: Dropdown to select when the path should be visible. Options are if enemy is selected, always or never.


### Workflow
- Add the EnemyPath component to your enemy prefab or object.
- Add waypoints to the `waypoint` List.
- Set the position of the waypoints. You can do this by setting them in the inspector or using the handles of the path in the scene.
- The Y axis can be locked by setting `Fix Y Axis` true.
- The handles can be changed from arrow handles to free move handles.
- The path color and visibility can be changed for each path individualy.

