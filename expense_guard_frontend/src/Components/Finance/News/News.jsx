import React from "react";
import "./News.css";

function News({
  title,
  description,
  linkTitle,
  imgPath = "...",
  linkUrl = "#",
}) {
  return (
    <div className="card w-25">
      <img className="card-img-top" src={imgPath} alt="" />
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{description}</p>
        <a href={linkUrl} className="btn btn-primary">
          {linkTitle}
        </a>
      </div>
    </div>
  );
}

export default News;
