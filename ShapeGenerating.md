<h1 align="center">ShapeGenerating</h1>
<p align="center">
To achieve diffrent shapes game uses procedular 2d shapes package from unity asset store.<br>
  Shape generation is used both for "backgroundshapes" at mainmenu and "remembershape".
</p>

<br>
<h2 align="center">BasicValues</h2>
<p align="center">
Script responsible for generating shape uses Random.Range to set values that all shapes use.<br>
These values are: scale, fillColor, outlineColor, and shapeType.<br>
The last value, shapeType is later used to generate values specific to this shape type.<br>
Exception is the outline, it is used by everyshape, but to cover whole shape with outline, diffrent values have to be used.<br>
This forces the outline to be handled in method specific for the shape.
</p>


<br>
<h2 align="center">ValusForSpecificShapeType</h2>
<p align="center">
Since each shape has diffrent settings, script uses array of delegates and shapeType enum to generate values that are only used by this shape.<br>
  1| Ellipse (angle, innerCutout)<br>
  2| Polygon (polygonPreset)<br>
  3| Rectangle (roundness for each corner)<br>
  4| Triangle (offset)<br>
  Each of those 4 shapes also generates outline size depending on scale and in case of Ellipse, innerCutout. 
</p>




<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
