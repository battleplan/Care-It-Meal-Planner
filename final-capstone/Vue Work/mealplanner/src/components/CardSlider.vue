<template>
    


    <div class="card-carousel-wrapper">
        <div class="card-carousel--nav__left" @click="moveCarousel(-1)" :disabled="atHeadOfList"></div>
        <div class="card-carousel">
            <div class="card-carousel--overflow-container">
                <div class="card-carousel-cards" :style="{ transform: 'translateX' + '(' + currentOffset + 'px' + ')'}">
                    <div class="card-carousel--card" v-bind:key ="item" v-for="item in items"><img src="https://placehold.it/200x200" />
                        <div class="card-carousel--card--footer">
                            <p>{{ item.name }}</p>
                            <p class="tag" v-bind:key ="index" v-for="(tag,index) in item.tag" :class="index &gt; 0 ? 'secondary' : ''">{{ tag }}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-carousel--nav__right" @click="moveCarousel(1)" :disabled="atEndOfList"></div>
    </div>

</template>

<script>
export default {
 name: "card-slider",
 data() {
    return {
      currentOffset: 0,
      windowSize: 3,
      paginationFactor: 220,
      items: [
        {name: 'Kin Khao', tag: ["Thai"]},
        {name: 'Jū-Ni', tag: ["Sushi", "Japanese", "$$$$"]},
        {name: 'Delfina', tag: ["Pizza", "Casual"]},
        {name: 'San Tung', tag: ["Chinese", "$$"]},
        {name: 'Anchor Oyster Bar', tag: ["Seafood", "Cioppino"]},
        {name: 'Locanda', tag: ["Italian"]},
        {name: 'Garden Creamery', tag: ["Ice cream"]},
      ]
    }
  },
  computed: {
    atEndOfList() {
      return this.currentOffset <= (this.paginationFactor * -1) * (this.items.length - this.windowSize);
    },
    atHeadOfList() {
      return this.currentOffset === 0;
    },
  },
  methods: {
    moveCarousel(direction) {
      // Find a more elegant way to express the :style. consider using props to make it truly generic
      if (direction === 1 && !this.atEndOfList) {
        this.currentOffset -= this.paginationFactor;
      } else if (direction === -1 && !this.atHeadOfList) {
        this.currentOffset += this.paginationFactor;
      }
    },
  }
}
</script>
<style scoped>
body {
background:#f8f8f8;
color:#2c3e50;
font-family: 'Source Sans Pro', sans-serif;
}
 .card-carousel-wrapper {
display: flex;
align-items: center;
justify-content: center;
margin: 20px 0 40px;
color: #666a73;
}
 .card-carousel {
display: flex;
justify-content: center;
width: 640px;
}
 .card-carousel--overflow-container {
overflow: hidden;
}
 .card-carousel--nav__left, .card-carousel--nav__right {
display: inline-block;
width: 15px;
height: 15px;
padding: 10px;
box-sizing: border-box;
border-top: 2px solid black;
border-right: 2px solid black;
cursor: pointer;
margin: 0 20px;
transition: transform 150ms linear;
}
 .card-carousel--nav__left[disabled], .card-carousel--nav__right[disabled] {
opacity: 0.2;
border-color: black;
}
 .card-carousel--nav__left {
transform: rotate(-135deg);
}
 .card-carousel--nav__left:active {
transform: rotate(-135deg) scale(0.9);
}
 .card-carousel--nav__right {
transform: rotate(45deg);
}
 .card-carousel--nav__right:active {
transform: rotate(45deg) scale(0.9);
}
 .card-carousel-cards {
display: flex;
transition: transform 150ms ease-out;
transform: translatex(0px);
}
 .card-carousel-cards .card-carousel--card {
margin: 0 10px;
cursor: pointer;
box-shadow: 0 4px 15px 0 rgba(40, 44, 53, .06), 0 2px 2px 0 rgba(40, 44, 53, .08);
background-color: #fff;
border-radius: 4px;
z-index: 3;
margin-bottom: 2px;
}
 .card-carousel-cards .card-carousel--card:first-child {
margin-left: 0;
}
 .card-carousel-cards .card-carousel--card:last-child {
margin-right: 0;
}
 .card-carousel-cards .card-carousel--card img {
vertical-align: bottom;
border-top-left-radius: 4px;
border-top-right-radius: 4px;
transition: opacity 150ms linear;
user-select: none;
}
 .card-carousel-cards .card-carousel--card img:hover {
opacity: 0.5;
}
 .card-carousel-cards .card-carousel--card--footer {
border-top: 0;
padding: 7px 15px;
background-color: #fba919;
}
 .card-carousel-cards .card-carousel--card--footer p {
padding: 3px 0;
margin: 0;
margin-bottom: 2px;
font-size: 19px;
font-weight: 500;
color: white;
user-select: none;
}
 .card-carousel-cards .card-carousel--card--footer p.tag {
font-size: 11px;
font-weight: 300;
padding: 4px;
background: rgba(40, 44, 53, .06);
display: inline-block;
position: relative;
margin-left: 4px;
color:white;
}
 .card-carousel-cards .card-carousel--card--footer p.tag:before {
content: "";
float: left;
position: absolute;
top: 0;
left: -12px;
width: 0;
height: 0;
border-color: transparent rgba(40, 44, 53, .06) transparent transparent;
border-style: solid;
border-width: 8px 12px 12px 0;
}
 .card-carousel-cards .card-carousel--card--footer p.tag.secondary {
margin-left: 0;

}
 .card-carousel-cards .card-carousel--card--footer p.tag.secondary:before {
display: none !important;
}
 .card-carousel-cards .card-carousel--card--footer p.tag:after {
content: "";
position: absolute;
top: 8px;
left: -3px;
float: left;
width: 4px;
height: 4px;
border-radius: 2px;
background: white;
box-shadow: 0px 0px 0px #004977;
}
 h1 {
font-size: 3.6em;
font-weight: 100;
text-align: center;
margin-bottom: 0;
color: #42b883;
}
 
</style>
