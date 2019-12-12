<template>
  <div id="app">
    <div id="nav">
      <nav class="dropdownmenu">
  <ul>
    <li><router-link to="/">Home</router-link></li>
    <li><a href="#">My Recipes</a>
		<ul id="submenu">
        <li><a href="/addrecipe">Add Recipe (WIP)</a></li>
    </ul>

	</li>
    <li><a href="#">Shopping List</a>
      <ul id="submenu">
        <li><a href="#">Placeholder</a></li>
        <li><a href="#">Placeholder</a></li>
      </ul>
    </li>
    <li><a href="#">Pantry</a></li>
    
    
  </ul>
</nav>
    </div>
    <router-view/>
  </div>
</template>

<script>
export default {
  
}
</script>
import Login from ''
<style scoped>

.dropdownmenu ul, .dropdownmenu li {
	margin: 0;
	padding: 0;
}
.dropdownmenu ul {
	background: gray;
	list-style: none;
	width: 100%;
}
.dropdownmenu li {
	float: left;
	position: relative;
	width:25%;
}
.dropdownmenu a {
	background: #fba919;
	color: #FFFFFF;
	display: block;
	font: bold 12px/20px sans-serif;
	padding: 10px 25px;
	text-align: center;
	text-decoration: none;
	-webkit-transition: all .25s ease;
	-moz-transition: all .25s ease;
	-ms-transition: all .25s ease;
	-o-transition: all .25s ease;
	transition: all .25s ease;
}
.dropdownmenu li:hover a {
	background: #c35e00;
}
#submenu {
	left: 0;
	opacity: 0;
	position: absolute;
	top: 35px;
	visibility: hidden;
	z-index: 1;
}
li:hover ul#submenu {
	opacity: 1;
	top: 40px;	/* adjust this as per top nav padding top & bottom comes */
	visibility: visible;
}
#submenu li {
	float: none;
	width: 100%;
}
#submenu a:hover {
	background: #ff0000;
}
#submenu a {
	background-color:#c35e00;
}
</style>