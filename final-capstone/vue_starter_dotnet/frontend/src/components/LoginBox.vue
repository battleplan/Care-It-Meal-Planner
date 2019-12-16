<template>
<section id="login" v-bind:class="isShake">
 <form v-on:submit.prevent="newLogin">
  <h2>Login</h2>
  <div v-if="alert.message" class="info" v-bind:class="good">
   <p>{{ alert.message }}</p>
   <p v-show="login.username && login.password">{{ login.username}} / {{ login.password}}</p>
  </div>
  <input type="text" v-model="login.username" placeholder="Username" />
  <input type="password" v-model="login.password" placeholder="Password" />
  <!-- TODO make just the text a link -->
  <router-link id="register-link" :to="{ name: 'register' }">Need an account?</router-link>
  <button >Log in</button>
 </form>
</section>
</template>

<script>
export default {
	
	name: "login-box",
	// prop:{
	// 	login2: {
	// 		username: String,
	// 		password: String
	// 	},
	// },
	data() {
        return{
		alert: {
			message: ""
		},
		login: {
			username: '',
			password: ''
		},
		shake: false,
		good: "",
		fake: {
			login: "vincent",
			password: "admin"
        }
        }
	},
	computed: {
		isShake: function(){
			//console.log(this.shake);
			if(this.shake == true){
				return 'shake'
			}
			return 'none'
		}
	},
	methods: {
		onSubmit: function(event) {
			event.preventDefault();
			this.shake = false
			setTimeout(function(){
				if (
				this.fake.login == this.login.login &&
				this.fake.password == this.login.password
			) {
				this.alert.message = "Hello Huston !";
			} else {
				this.shake = true;
				this.alert.message = "Huston, we got a problem !";
			}
			},3000)
			//console.log(this.shake)
			
		},
		newLogin: function(){
			this.$emit('new-login', this.login)
		}
	}
}

</script>


<style scoped>
html, body{
width:100%;
height:100%;
margin:0px;
font-family: 'Work Sans', sans-serif;
}

body{
background-image:url('https://images-assets.nasa.gov/image/6900952/6900952~orig.jpg');
background-size: cover;
display: flex;
flex-direction:column;
justify-content:center;
align-items:center;
color: #fff;
}

section{
background-color: rgba(0, 0, 0, 0.72);
width:25%;
min-height:25%;
display:flex;
flex-direction:column;
	/*margin-left:auto;
	margin-right:auto;*/
}
form{
display:flex;
flex-direction:column;
padding: 15px; 
}
h2{
font-family: 'Archivo Black', sans-serif;
color:#e0dada;
margin-left:auto;
margin-right:auto;
}

.info{
width:100%;
padding: 1em 5px;
text-align:center;
min-height:45px;
display:flex;
flex-direction:column;
justify-content:center;
align-items:center;
}

.info.error{
border:1px solid #a90e00;
background-color: #ff3c41;
color:#a90e00;
}
.info p{
margin:auto;
padding:5px;
}
.info.good{
border:1px solid #416d50;
background-color: #47cf73;
color:#416d50;
}

input{
height:35px;
padding: 5px 5px;
margin: 10px 0px;
background-color:#e0dada;
border:none;
}
button{
height:40px;
padding: 5px 5px;
margin: 10px 0px;
font-weight:bold;
background-color:#fba919;
border:none;
color:#e0dada;
cursor:pointer;
font-size:16px;
}
button:hover{
background-color:#711f1b;
}

#register-link {
	color: orange;
	text-align: center;
}

@-webkit-keyframes shake{
from, to{
-webkit-transform: translate3d(0, 0, 0);
transform:translate3d(0,0,0);
	}
10%,30%,50%,70%,90%{
-webkit-transform: translate3d(-10px, 0, 0);
transform:translate3d(-10px,0,0);
	}
20%,40%,60%,80%{
-webkit-transform: translate3d(10px, 0, 0);
transform:translate(10px,0,0);
	}
}

.shake{
animation-name: shake;
animation-duration:1s;
/*animation-fill-mode: both;*/
}

@media screen and (max-width: 780px) {
section{
width:90%;
	}
}
</style>