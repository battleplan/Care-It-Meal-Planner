<template>
  <div id="app">
    <div id="nav">
      <nav class="dropdownmenu">
  <ul>
    <li><router-link to="/">Home</router-link></li>
    <li><a href="/addrecipe">Add Recipe</a>
		<!-- <ul id="submenu">
        <li></li>
    </ul> -->

	</li>
    <li><a href="/test">Meal Planner</a>
      <!-- <ul id="submenu">
        <li><a href="/calendar">Old Calendar</a></li>
      </ul> -->
    </li>
    <li><a href="/" v-on:click="logout()">Logout</a></li>
    
    
  </ul>
</nav>
<img id="background" src="../public/background_img.jpg" />
    <video autoplay muted loop id="myVideo">
  <source src="FoodBackground2.mp4" type="video/mp4">
</video></div>
    <router-view/>
  </div>
</template>

<script>
export default {
  
methods: {
	logout (){
	window.localStorage.removeItem('Authorization');
	this.$router.push('/');
	}
  }
}
</script>
import Login from ''
<style scoped>


body {
	margin: 0px;
}

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
li:hover ul#submenu{
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

#background {
	z-index: -10;
	width: 100%;
	position: absolute;
	top: 0px;
	left: 0px;
	filter:brightness(70%)
	}

div#app {
	position: absolute;
	width: 100%;
	margin: 0px;
}
#myVideo {
  position: fixed;
  right: 0;
  bottom: 0;
  min-width: 100%;
  min-height: 100%;
  z-index: -1;
}
</style>