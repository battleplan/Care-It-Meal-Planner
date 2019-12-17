<template>
  <div id="login" class="text-center">
    <!-- <form class="form-signin" @submit.prevent="login">
<div id="greeting">
      <h1 id="h3 mb-3 font-weight-normal">Please Sign In</h1>
</div>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div id="signInCard">
      <div id="username">
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      </div>
      <div id="password">
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      </div>
      <div id="reg">
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
      <button type="submit">Sign in</button>
      </div>
      </div>
    </form> -->
    <login-box v-on:new-login="dealWithIt"></login-box>
  </div>
</template>

<script>
import auth from '../auth';
import LoginBox from '../components/LoginBox.vue';

export default {
  name: 'login',
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      invalidCredentials: false,
    };
  },
  components:{
    LoginBox
  },
  methods: {
    login() {
      fetch(`https://localhost:5001/api/accounts/login`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then((token) => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, '');
            }
            auth.saveToken(token);
            this.$router.push('/');
          }
        })
        .catch((err) => console.error(err));
    },
    dealWithIt(lo){
      this.user = lo;
      this.login();
    }
  },
};
</script>

<style>
#signInCard{
margin: auto;
 background-color: #fba919;
 border-radius: 10px;
 width: 25%;
 padding: 2%;
}
#greeting{
text-align: center;

}
#username{
  
  text-align: center;
  
}
#password{
  
  text-align: center;
  
}
#reg{
  
  text-align: center;
  
}
</style>
