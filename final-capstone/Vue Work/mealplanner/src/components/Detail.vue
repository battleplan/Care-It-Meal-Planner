<template>
    <div id="card-box">
        <div id="logo">
<img id="display-image" src="@/components/mac.jpg">
<img id="blurred-image" src="@/components/mac.jpg">
        </div>
<span>
    <h1>
        {{name}}
    </h1>
</span>
<h2 id="tags">
    {{category}} {{cooktime}}
</h2>
<p id="ingredients">
{{ingredients}}
</p>
<p id="instructions">
    {{instructions}}
</p>
    </div>
</template>

<script>
export default {
    name:"detail",
}
</script>

<style scoped>
#blurred-image{
    width: 400px;
    height: 400px;
    filter:blur(8px);
    transform: rotate(90deg);
    /* The points are: centered top, left bottom, right bottom */
    clip-path: polygon(0% 0, 0 100%, 100% 100%);
}
#logo #display-image{
    position: absolute; 
    z-index: 100;
    top: 300px;
    left: 490px;
}
#logo #blurred-image{
    position: absolute;
    z-index: -100;
    top: 200px;
    left: 400px;
}
</style>