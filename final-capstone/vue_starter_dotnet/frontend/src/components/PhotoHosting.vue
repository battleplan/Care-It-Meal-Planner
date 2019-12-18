<!-- 
  NOTES:
  - Images actually need to be hosted on an image hosting service (e.g. Cloudinary).
  - The component posts the image to Cloudinary using a 3rd party called dropzone.
  - The sharePhoto method POSTS a new Post with the hosted imageUrl
    and the caption that the user provides.

  DEPENDENCIES:

    Vue-DropZone
    Cloudinary    
-->

<template>
  <div id="new-post" class="container">
    <h2>Upload a photo to share</h2>
    <form id="post-form" v-on:submit.prevent="sharePhoto">
      <vue-dropzone
        id="dropzone"
        v-bind:options="dropzoneOptions"
        v-on:vdropzone-sending="addFormData"
        v-on:vdropzone-success="getSuccess"
      ></vue-dropzone>
      <input
        type="text"
        name="caption"
        id="caption"
        v-model="post.caption"
        autocomplete="off"
        placeholder="Add a caption..."
      />
      <div class="form-actions">
        <button v-bind:disabled="!canPost" id="share">Share</button>
        <router-link to="/" tag="button">Cancel</router-link>
      </div>
    </form>
  </div>
</template>

<script>
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";
import auth from "@/auth.js";

export default {
  name: "photo-hosting",
  components: {
    vueDropzone: vue2Dropzone
  },
  data() {
    return {
      dropzoneOptions: {
        // tutorials
        // https://danhough.com/blog/dropzone-cloudinary/ 
        // https://alligator.io/vuejs/vue-dropzone/
        url: "https://api.cloudinary.com/v1_1/icedapple/image/upload",  //this is my url for cloudinary
        thumbnailWidth: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultipe: false
      },
      post: {
        imageUrl: "",
        caption: ""
      }
    };
  },
  computed: {
    canPost() {
      return this.post.caption && this.post.image;
    }
  },
  methods: {
    
showUploadWidget() {
 cloudinary.openUploadWidget({
    cloudName: "icedapple",
    uploadPreset: "<upload preset>",
    sources: [
        "local"
    ],
    googleApiKey: "<image_search_google_api_key>",
    showAdvancedOptions: true,
    cropping: true,
    multiple: false,
    defaultSource: "local",
    styles: {
        palette: {
            window: "#FFFFFF",
            windowBorder: "#90A0B3",
            tabIcon: "#0078FF",
            menuIcons: "#5A616A",
            textDark: "#000000",
            textLight: "#FFFFFF",
            link: "#0078FF",
            action: "#FF620C",
            inactiveTabIcon: "#0E2F5A",
            error: "#F44235",
            inProgress: "#0078FF",
            complete: "#20B832",
            sourceBg: "#E4EBF1"
        },
        fonts: {
            default: {
                active: true
            }
        }
    }
},
 (err, info) => {
   if (!err) {    
     console.log("Upload Widget event - ", info);
   }
  });
 },
    
    /**
     * Called before sending the request to add additional headers.
     * @function
     */
    addFormData(file, xhr, formData) {
      formData.append("api_key", "947599519755173");  // my api key
      formData.append("upload_preset", "vg8sew4g"); // my upload preset
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("tags", "vue-app");
    },
    /**
     * Called after an upload success to get the image url.
     * @function
     */
    getSuccess(file, response) {
      this.post.imageUrl = response.secure_url;
    },
    /**
     * POSTs a new Post
     * @function
     */
    sharePhoto() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/posts`, {
        method: "POST",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.post)
      })
        .then(response => {
          if (response.ok) {
            this.$router.push("/");
          }
        })
        .catch(err => {
          console.log(err);
        });
    }
  }
};
</script>

<style scoped>

</style>