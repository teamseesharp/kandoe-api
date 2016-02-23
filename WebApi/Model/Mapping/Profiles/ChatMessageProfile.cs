﻿using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class ChatMessageProfile : Profile {
        protected override void Configure() {
            this.CreateMap<ChatMessage, ChatMessageDto>();
            this.CreateMap<ChatMessageDto, ChatMessage>();
        }
    }
}