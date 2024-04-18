import React from 'react'
import './News.css'

function News({title, description, linkTitle,  imgPath = '...', linkUrl='#'}) {
    return <div class="card w-25">
                <img class="card-img-top" src={imgPath} alt=''/>
                <div class="card-body">
                <h5 class="card-title">{title}</h5>
                <p class="card-text">{description}</p>
                <a href={linkUrl} class="btn btn-primary">{linkTitle}</a>
                </div>
            </div>
}

export default News;