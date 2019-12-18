<template>
  <div id="register" class="text-center">
    <form id="regform" class="form-register" @submit.prevent="register">
      <h2 class="h3 mb-3 font-weight-normal">Create Account</h2>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        There were problems registering this user.
      </div>
      <label for="username" class="sr-only"></label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only"></label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <br />
      <router-link id="login-link" :to="{ name: 'login' }">
        Have an account?
      </router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
  </div>
</template>

<script>
export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
    };
  },
  methods: {
    register() {
      fetch(`https://localhost:5001/api/accounts/register`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/login', query: { registration: 'success' } });
          } else {
            this.registrationErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
};
</script>

<style>
#regform {
  background-color: rgba(0, 0, 0, 0.72);
  width: 25%;
  margin:auto;
  margin-top: 10%;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  flex-direction: column;
  padding: 15px;
  
}

.sr-only{
font-family: 'Archivo Black', sans-serif;
color:#e0dada;
margin-left:auto;
margin-right:auto;
text-align: center;
}

h2{
font-family: 'Archivo Black', sans-serif;
color:#e0dada;
margin-left:auto;
margin-right:auto;
text-align: center;
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

#login-link {
	color: orange;
	text-align: center;
}
#register{
display: block;
text-align: center;
margin: auto;
margin-top: 10%;
}
#confirmPassword{
  text-align: left;
  padding: 5px 5px;
  margin: 10px 0px;
  background-color: #e0dada;
  border: none;
}
#username{
  text-align: left;
  padding: 5px 5px;
  margin: 10px 0px;
  background-color: #e0dada;
  border: none;
}
#password{
  text-align: left;
  padding: 5px 5px;
  margin: 10px 0px;
  background-color: #e0dada;
  border: none;
}
</style>
