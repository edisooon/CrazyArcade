Functionality can be described in a basic way in this file. 

The way the UI system has been currently designed works as follows

The class must be loaded into the main game class as its own field. It then should then be called at the end of the draw method in the main game.
Doing this means that anything drawn in the GUI will nessisarily be done so over top of everything else, regardless of that draw order.

To draw something to the GUI, one must construct a GUI_Composition, either at runtime, or by defining it in its own class.

To creat a GUI_Composition you must first give it a unique name. Then, give it GUI_Components, with unique names relative to the parent GUI_Composition.
These GUI_Components can either be sprite based or font based.

In order to add to this GUI class after a Composition has been constructed, you have to use the UI_Singleton, which is globally accessable. Use any of the
methods provided there in order to update the state of the GUI.