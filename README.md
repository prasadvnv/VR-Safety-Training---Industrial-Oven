# VR-Safety-Training--Industrial-Oven
This project leverages virtual reality to create an immersive training environment for enhancing workplace safety around industrial ovens. Developed using Unity and tested on Meta Oculus, the simulation provides a hands-on experience in identifying hazards and practicing safety protocols in a risk-free setting. 
[Click here to view the VR Project presentation](./VR%20Project.pdf)

## Demo Video
⚠️ Note: This demo was recorded on a PC setup, which does not reflect the smoother performance on Oculus Quest.
Watch the VR demo here: [https://screenrec.com/share/AfREolQXIN](https://screenrec.com/share/AfREolQXIN)


## Initial Blender Model Preview

[Watch Blender Model Video](https://drive.google.com/file/d/16APkMMeMTkFBTtj44pjxQglTqKbNaADl/view?usp=sharing)

## Features
- Oven Control: Start/Stop the oven using a dropdown menu with integrated time control. The oven's temperature is displayed, and it automatically shuts down if it exceeds 1200°C.
- Emergency Stop: A manual emergency switch and automatic shutdown if the temperature exceeds 1200°C. An emergency panel and alarm system are activated upon critical temperature.
- Particle Fire Extinguisher: Automatic fire extinguishing system activated through particle effects (smoke particles) and sound.
- User Safety: Real-time UI canvas pop-up alert for temperature limits. Safety zone and warning messages will appear when the oven exceeds the temperature limit.
- User Protection: Gloves and safety glasses are required during operation, with a toggle for users to check if they are properly equipped. Safety posters are also displayed.
- Interactive Controls: The user can control various safety features like the exhaust fan, oven light, and door from within the VR environment.
- Real-time UI Updates: Temperature readings, status indicators, and time remaining are continuously updated in the UI.
## Key Scripts
- OvenController: Manages the oven's operation, including temperature control, emergency stop, and UI updates.
- ParticleControl: Controls the particle system for the fire extinguishing mechanism, including audio feedback.
- PlayerControllerRigidBody: Handles player movement and rotation within the VR environment using rigidbody physics.
- AnimateHandOnInput: Controls hand animations based on input from the VR controller's pinch and grip actions.
- HoverAndDisappear: Ensures that the user is wearing gloves and safety glasses before operating the oven and changes the material of safety equipment accordingly.
## Requirements
- Unity 3D with the necessary VR packages (e.g., XR Interaction Toolkit)
- VR hardware (Oculus/HTC Vive/Valve Index)
- TextMeshPro and Unity's Particle System
- Unity's Rigidbody and UI components for player interaction
## Setup
- Clone the repository to your local machine.
- Open the project in Unity.
- Ensure all dependencies (like TextMeshPro and the necessary VR packages) are installed.
- Connect your VR hardware and set up the XR interaction system.
- Build and run the project in your VR environment.
## Future Work:
- Integrate ROS for task automation simulation
- Add real-time data feedback for training performance
## Safety Note
This project simulates a real-world oven safety system. Always ensure to follow real-world safety protocols when working with actual industrial equipment.
